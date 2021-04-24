using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner_Cont : MonoBehaviour
{
    public Transform bulletSpawner;
    public float bulletForce=10f;
    public GameObject bulletPrefab;

    public Animator animBody;
    public Animator animGun;
    public Animator animWheel;

    public bool isOnShootingMode = false;
    bool alreadyShoot = false;
    // Start is called before the first frame update

    AudioManager audiomanager;
    void Start()
    {
        audiomanager = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    public float moveSpeed=1;
    void Update()
    {
        if (isPlayerInfront())
        {
            animBody.SetFloat("Speed", 0);
            animWheel.SetFloat("Speed", 0);

            isOnShootingMode = true;
        }
        else {
            isOnShootingMode = false;
            animBody.SetFloat("Speed", 1);
            animWheel.SetFloat("Speed", 1);

            if (IsGrounded())
            {

                if (transform.localScale.x == -1)
                {
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                }
                else {
                    transform.Translate(Vector2.right * moveSpeed *Time.deltaTime);
                }
               

            }
            else {
                Vector3 newScale = this.transform.localScale;
                newScale.x *= -1;
                this.transform.localScale = newScale;
            }
        }

        if (isOnShootingMode)
        {
            animBody.SetBool("ShootingMode", true);
            if (!alreadyShoot)
            {
                alreadyShoot = true;
                StartCoroutine(shootDelay());
            }
        }
        else {
            animBody.SetBool("ShootingMode", false);
            alreadyShoot = false;
            StopAllCoroutines();
        }
    }

    IEnumerator shootDelay() {
        Shoot();
        yield return new WaitForSeconds(1);
        
        StartCoroutine(shootDelay());
    }

    void Shoot() {
        audiomanager.Play("Shoot");
        int direction;
        if (transform.localScale.x == -1) direction = -1;
        else direction = 1;
        animGun.SetTrigger("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce((bulletSpawner.right * direction) * bulletForce, ForceMode2D.Impulse);

        
    }

    public LayerMask groundLayer;
    // [SerializeField]
    float distance = 0.4f;
     //[SerializeField]
    float RayOffsetxL = 0.3f;
    //[SerializeField]
    float RayOffsety = -0.2f;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        //float distance = 1.0f;
        if (transform.localScale.x == 1)
        {
            RayOffsetxL = Mathf.Abs(RayOffsetxL);
        }
        else {
            RayOffsetxL *= -1;
        }
        Debug.DrawRay(position + new Vector2(RayOffsetxL, RayOffsety), direction * distance, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(position + new Vector2(RayOffsetxL, RayOffsety), direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }



        return false;
    }

    public LayerMask playerLayer;
   // [SerializeField]
    public float distanceSensor = 4;
   // [SerializeField]
    float RayOffsetxLSensor = 0;
    //[SerializeField]
    float RayOffsetySensor = 0f;
    bool isPlayerInfront() {
        Vector2 position = transform.position;
        Vector2 direction;
        if (transform.localScale.x == -1)
        {
            direction = Vector2.left;
        }
        else {
            direction = Vector2.right;
        }
        
        //float distance = 1.0f;

        Debug.DrawRay(position + new Vector2(-RayOffsetxLSensor, RayOffsetySensor), direction * distanceSensor, Color.yellow);

        RaycastHit2D hit = Physics2D.Raycast(position + new Vector2(-RayOffsetxLSensor, RayOffsetySensor), direction, distanceSensor, playerLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountedGun_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform TargetObjTransform;
    public Transform bulletSpawner;
    public float bulletForce = 10f;
    public GameObject bulletPrefab;

    public Animator animGun;

    public float range;
    bool isPlayerInfront;

    public bool isOnShootingMode = false;
    bool alreadyShoot = false;
    // Start is called before the first frame update

    AudioManager audiomanager;
    void Start()
    {
        TargetObjTransform = GameObject.Find("Tank").GetComponent<Transform>();
        audiomanager = GetComponent<AudioManager>();
    }

    public float speed=200;

    void checkPlayerDistance() {
        float distanceDiff = Vector2.Distance(transform.position, TargetObjTransform.position);
        if (distanceDiff <= range)
        {
            isPlayerInfront = true;
        }
        else {
            isPlayerInfront = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Lookat();
        checkPlayerDistance();
        if (isPlayerInfront)
        {
            isOnShootingMode = true;
        }
        else
        {
            isOnShootingMode = false;
        }

        if (isOnShootingMode)
        {
            if (!alreadyShoot)
            {
                alreadyShoot = true;
                StartCoroutine(shootDelay());
            }
        }
        else
        {
            alreadyShoot = false;
            StopAllCoroutines();
        }

       
    }

    void Lookat() {
        float angle = Mathf.Atan2(TargetObjTransform.position.y - transform.position.y, TargetObjTransform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
    IEnumerator shootDelay()
    {
        Shoot();
        float randNum = Random.Range(3, 7);
        yield return new WaitForSeconds(randNum);

        StartCoroutine(shootDelay());
    }

    void Shoot()
    {
        audiomanager.Play("Shoot");
        animGun.SetTrigger("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce((bulletSpawner.right) * bulletForce, ForceMode2D.Impulse);


    }

}

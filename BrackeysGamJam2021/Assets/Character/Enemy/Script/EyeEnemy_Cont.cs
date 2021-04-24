using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemy_Cont : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawner;
    // Start is called before the first frame update

    AudioManager audiomanager;
    void Start()
    {
        audiomanager = GetComponent<AudioManager>();
        StartCoroutine(shootDelay());
    }

    public bool isMovetoRight=false;
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public float moveSpeed = 1;
    void Movement() {
        if (isMovetoRight == false)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            if (isMovetoRight == false) isMovetoRight = true;
            else isMovetoRight = false;
        }
    }

    IEnumerator shootDelay()
    {
        int randomDelay = Random.Range(3, 6);
        yield return new WaitForSeconds(randomDelay);
        Shoot();
        StartCoroutine(shootDelay());
    }

    void Shoot()
    {
        audiomanager.Play("Shoot");
        Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);


    }
}

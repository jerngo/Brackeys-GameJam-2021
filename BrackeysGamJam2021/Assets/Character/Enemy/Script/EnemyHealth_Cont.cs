using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_Cont : MonoBehaviour
{
    public int HealthPoint = 5;
    public GameObject EnemyDeathParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoint <= 0) {
            Instantiate(EnemyDeathParticle, transform.position, transform.rotation);
            GetComponent<AudioManager>().Play("DeathSound");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            HealthPoint -= 1;
        }

        if (collision.gameObject.tag == "Player") {
            HealthPoint = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthPoint = 0;
        }

        if (collision.gameObject.tag == "ScreenLimit") {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Lava") {
            Destroy(this.gameObject);
        }
    }
}

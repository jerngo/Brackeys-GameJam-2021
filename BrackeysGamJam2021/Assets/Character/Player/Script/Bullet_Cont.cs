using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Cont : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject gunSpark;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public float speed = 20;

    void Update()
    {

    }
    public string Ignore = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag != Ignore)
        {
            if (collision.gameObject.tag == "Border")
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            else {
                Instantiate(gunSpark, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
           
        }
        if (Ignore == "Enemy") {
            if (collision.gameObject.tag == "BombShell") {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }

        if (Ignore == "HugeBullet")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        }
    }
}

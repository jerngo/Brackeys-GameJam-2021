using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionSphere : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PlayeBlue")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        }

        if (collision.gameObject.name == "PlayeGreen")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        }
        if (collision.gameObject.tag == "ScreenLimit")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        }
    }
}

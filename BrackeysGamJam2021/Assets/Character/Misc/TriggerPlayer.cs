using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    public GameObject[] spawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            foreach (GameObject spawn in spawner) {
                spawn.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}

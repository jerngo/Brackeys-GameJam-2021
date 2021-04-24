using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject spawnParticle;

    public float time;
    void Start()
    {
        StartCoroutine(timerSpawn());
    }

    IEnumerator timerSpawn()
    {
        float timeX = Random.Range(time, time * 2);
        yield return new WaitForSeconds(timeX);
        GetComponent<AudioManager>().Play("Teleport");
        Instantiate(enemy, transform.position, transform.rotation);
        Instantiate(spawnParticle, transform.position, transform.rotation);
        StartCoroutine(timerSpawn());
    }

    int enemyCount;
    // Update is called once per frame
}

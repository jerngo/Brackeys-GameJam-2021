using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bomb;
    public float time;
    void Start()
    {
        StartCoroutine(timerSpawn());
    }

    IEnumerator timerSpawn() {
        float timeX = Random.Range(time, time*2);
        yield return new WaitForSeconds(timeX);
        Instantiate(bomb, transform.position, transform.rotation);
        StartCoroutine(timerSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpark_Cont : MonoBehaviour
{
    public GameObject gunSpark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
    }

}

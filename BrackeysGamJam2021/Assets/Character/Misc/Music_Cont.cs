using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Cont : MonoBehaviour
{
    static Music_Cont instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor() {
        GetComponent<Animator>().SetBool("Open", true);
        GetComponent<AudioManager>().Play("OpenDoor");
    }

    public void CloseDoor()
    {
        GetComponent<Animator>().SetBool("Open", false);
        GetComponent<AudioManager>().Play("OpenDoor");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Cont : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool isOpen = false;
    public bool isPlatformCont = false;
    public Rigidbody2D platform;
    public bool isForLift = false;
    void OpenSwitch() {
        GetComponent<Animator>().SetBool("Open", true);
        GetComponent<AudioManager>().Play("Pressed");
        if (door != null) {
            door.GetComponent<Door_Cont>().OpenDoor();
            
        }
        
        if (isPlatformCont) {
            platform.bodyType = RigidbodyType2D.Dynamic;
        }
        if (isForLift) {
            platform.gameObject.GetComponent<Animator>().SetBool("On", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"|| collision.gameObject.tag == "Bullet") {
            if (!isOpen) {
                isOpen = true;
                OpenSwitch();
            }
            
        }
    }
}

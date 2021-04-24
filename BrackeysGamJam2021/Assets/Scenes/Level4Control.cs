using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Control : MonoBehaviour
{
    public GameObject duoMountGun;
    public GameObject doorLeft;
    public GameObject doorRight;
    public Animator background;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    float timer=120;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool isStarted;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            background.SetBool("Move", false);
            GetComponent<AudioManager>().Stop("Gear");
            GetComponent<AudioManager>().Play("GearStop");
        }
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1);
        //GetComponent<AudioManager>().Play("Bip");
        timer -= 1;
        StartCoroutine(countdown());

    }
    void StartLevel() {
        duoMountGun.SetActive(true);
        doorRight.GetComponent<Door_Cont>().OpenDoor();
        doorRight.GetComponent<Door_Cont>().CloseDoor();
        doorRight.GetComponent<TimerDoor>().enabled=true;
        StartCoroutine(countdown());
        doorLeft.GetComponent<Door_Cont>().CloseDoor();

        spawner1.SetActive(true);
        spawner2.SetActive(true);
        spawner3.SetActive(true);
        spawner4.SetActive(true);

        GetComponent<AudioManager>().Play("Gear");
        background.SetBool("Move", true);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (!isStarted) {
                StartLevel();
                isStarted = true;
                GetComponent<Collider2D>().enabled = false;
            }
            
        }
    }
}

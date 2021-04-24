using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Cont : MonoBehaviour
{

    public GameObject doorLeft;

    public GameObject spawner1;


    // Start is called before the first frame update
    void Start()
    {

    }

    bool isStarted;

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1);
        //GetComponent<AudioManager>().Play("Bip");
        //timer -= 1;
        StartCoroutine(countdown());

    }
    void StartLevel()
    {
        doorLeft.GetComponent<Door_Cont>().CloseDoor();

        spawner1.SetActive(true);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isStarted)
            {
                StartLevel();
                isStarted = true;
                GetComponent<Collider2D>().enabled = false;
            }

        }
    }
}

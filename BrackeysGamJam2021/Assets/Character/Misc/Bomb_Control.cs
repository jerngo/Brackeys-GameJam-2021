using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomb_Control : MonoBehaviour
{

    public int timer=5;
    // Start is called before the first frame update
    void Start()
    {
       

        timerText.text = timer.ToString();
    }

    bool isGreenNear = false;
    bool isBlueNear = false;

    public GameObject blueTextDefuse;
    public GameObject greenTextDefuse;

    public Text timerText;

    public GameObject bombDestroyParticle;

    bool readyToExplode=false;
    // Update is called once per frame
    void Update()
    {
        blueTextDefuse = GameObject.Find("BlueTextDefuse");
        greenTextDefuse = GameObject.Find("GreenTextDefuse");
        if (readyToExplode) {
            readyToExplode = false;
            StartCoroutine(countdown());
        }

        if (timerText.text != "ERROR") {
            timerText.text = timer.ToString();
        }
        if(timer<=0) explode();

        if (isBlueNear) {
            if (Input.GetButtonUp("Action")) {
                defused();
            }
        }

        if (isGreenNear) {
            if (Input.GetButtonUp("Action2"))
            {
                defused();
            }
        }
    }

    IEnumerator countdown() {
        yield return new WaitForSeconds(1);
        GetComponent<AudioManager>().Play("Bip");
        timer -= 1;
        StartCoroutine(countdown());
        
    }

    void explode() {
        Instantiate(bombDestroyParticle, transform.position, transform.rotation);
        //GetComponent<AudioManager>().Play("Exploded");
        GetComponent<BulletCirclePattern>().fireProjectiles();
        Destroy(this.gameObject);
      
    }

    void defused() {
        
        StopAllCoroutines();
        timerText.text = "ERROR";
        StartCoroutine(willbegone());
    }

    IEnumerator willbegone() {
        GetComponent<AudioManager>().Play("Defused");
        yield return new WaitForSeconds(1);
        Instantiate(bombDestroyParticle, transform.position, transform.rotation);
        
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayeBlue") {
            isBlueNear = true;
            //blueTextDefuse.SetActive(true);
            blueTextDefuse.GetComponent<Text>().text = "[E] to defuse";
        }

        if (collision.gameObject.name == "PlayeGreen") {
            isGreenNear = true;
            //greenTextDefuse.SetActive(true);
            greenTextDefuse.GetComponent<Text>().text = "[/] to defuse";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayeBlue")
        {
            isBlueNear = false;
            //blueTextDefuse.SetActive(false);
            blueTextDefuse.GetComponent<Text>().text = "";
        }

        if (collision.gameObject.name == "PlayeGreen")
        {
            isGreenNear = false;
            //greenTextDefuse.SetActive(false);
            greenTextDefuse.GetComponent<Text>().text = "";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ScreenLimit")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.gameObject.tag == "Ground") {
            readyToExplode = true;
        }
    }
}

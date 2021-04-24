using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public Text timerText;
    void Start()
    {
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (timerText.text != "0")
        {
            timerText.text = timer.ToString();
        }

        if (timer <= 0) {
            GetComponent<Door_Cont>().OpenDoor();
        }
    }

    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1);
        //GetComponent<AudioManager>().Play("Bip");
        timer -= 1;
        StartCoroutine(countdown());

    }
}

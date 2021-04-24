using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBoss_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject[] circles;

    public GameObject spawner;
    public GameObject doorRight;


    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(shootDelay());
    }
    public GameObject destroyBossParticle;
    // Update is called once per frame
    void Update()
    {
        if (circleRemaining <= 0) {
            Instantiate(destroyBossParticle, transform.position, transform.rotation);
            doorRight.GetComponent<Door_Cont>().OpenDoor();
            spawner.SetActive(false);
            Destroy(this.gameObject);
        }
        checkCirclesLeft();

    }
    int circleRemaining = 5;
    void checkCirclesLeft() {
        circleRemaining = 0;
        foreach (GameObject circle in circles) {
            if (circle != null) circleRemaining += 1;
        }
    }
    IEnumerator shootDelay()
    {
        int randomAtk = Random.Range(1, 3);
        int randomTimer = Random.Range(5, 10);

        if (randomAtk == 1)
        {
            anim.SetTrigger("Attack1");
        }
        else {
            anim.SetTrigger("Attack3");
        }

        yield return new WaitForSeconds(randomTimer);
        StartCoroutine(shootDelay());
        
    }

    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject bottomArm;

    void shootCircleArm() {
        leftArm.GetComponent<BulletCirclePattern>().fireProjectiles();
        rightArm.GetComponent<BulletCirclePattern>().fireProjectiles();
        GetComponent<AudioManager>().Play("Shoot");
    }

    void shootBottomArm() {
        bottomArm.GetComponent<BulletCirclePattern>().fireProjectiles();
        GetComponent<AudioManager>().Play("Shoot");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth_Cont : MonoBehaviour
{
    public float HealthPoint = 10;
    public GameObject EnemyDeathParticle;

    public GameObject bar1;
    public GameObject bar2;
    public GameObject bar3;
    public GameObject bar4;
    public GameObject bar5;
    public GameObject bar6;

    public Vector3 lastPosition;

    float HPdividedsix;
    float maxHP;
    // Start is called before the first frame update
    void Start()
    {
        HPdividedsix = HealthPoint / 6;
        maxHP = HealthPoint;
    }

    private void Awake()
    {
        StopAllCoroutines();
        StartCoroutine(SaveLastPosition());
    }
    // Update is called once per frame
    void Update()
    {
        if (HealthPoint <= maxHP - HPdividedsix * 1 && HealthPoint >= maxHP - HPdividedsix * 2) {
            bar6.SetActive(false);
        }
        if (HealthPoint <= maxHP - HPdividedsix * 2 && HealthPoint >= maxHP - HPdividedsix * 3)
        {
            bar6.SetActive(false);
            bar5.SetActive(false);
        }
        if (HealthPoint <= maxHP - HPdividedsix * 3 && HealthPoint >= maxHP - HPdividedsix * 4)
        {
            bar6.SetActive(false);
            bar5.SetActive(false);
            bar4.SetActive(false);
        }
        if (HealthPoint <= maxHP - HPdividedsix * 4 && HealthPoint >= maxHP - HPdividedsix * 5)
        {
            bar6.SetActive(false);
            bar5.SetActive(false);
            bar4.SetActive(false);
            bar3.SetActive(false);
        }
        if (HealthPoint <= maxHP - HPdividedsix * 5 && HealthPoint >= maxHP - HPdividedsix * 6)
        {
            bar6.SetActive(false);
            bar5.SetActive(false);
            bar4.SetActive(false);
            bar3.SetActive(false);
            bar2.SetActive(false);
        }
        if (HealthPoint <= maxHP - HPdividedsix * 6)
        {
            bar6.SetActive(false);
            bar5.SetActive(false);
            bar4.SetActive(false);
            bar3.SetActive(false);
            bar2.SetActive(false);
            bar1.SetActive(false);
        }

        if (HealthPoint <= 0)
        {
            Instantiate(EnemyDeathParticle, transform.position, transform.rotation);
            GetComponent<AudioManager>().Play("DeathSound");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator SaveLastPosition()
    {
        lastPosition = transform.position;
        yield return new WaitForSeconds(10);
        StartCoroutine(SaveLastPosition());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            HealthPoint -= 1;
        }

        if (collision.gameObject.name == "CircleHuge(Clone)")
        {
            if (this.gameObject.name != "Tank")
            {
                HealthPoint -= 1;
            }
            else
            {
                HealthPoint -= 1;
            }

        }

        if (collision.gameObject.tag == "Enemy")
        {

            if (this.gameObject.name != "Tank")
            {
                HealthPoint -= HPdividedsix;
            }
            else
            {
                HealthPoint -= 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (this.gameObject.name != "Tank")
            {
                HealthPoint -= HPdividedsix;
            }
            else {
                HealthPoint -= 0;
            }
            
        }

        if (collision.gameObject.name == "CircleHuge(Clone)")
        {
            if (this.gameObject.name != "Tank")
            {
                HealthPoint -= 1;
            }
            else
            {
                HealthPoint -= 1;
            }
            
        }

        if (collision.gameObject.tag == "Lava")
        {

            HealthPoint = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrelScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunnerHolder;
    public Transform bulletSpawner;

    Animator anim;

    public GameObject bulletPrefab;
    public Tank_Cont tankCont;

    AudioManager audioManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (tankCont.isBlueOnBoard) {
            if (Input.GetButtonUp("Jump"))
            {
                audioManager.Play("GunShoot");
                Shoot();
            }
        }
        
    }
    void FixedUpdate()
    {
        if (gunnerHolder != null)
        {
            transform.position = gunnerHolder.position;
        }
        else {
            Destroy(this.gameObject);
        }
       
    }

    public float bulletForce = 1;
    void Shoot()
    {

        //DustPlay();
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce((bulletSpawner.right) * bulletForce, ForceMode2D.Impulse);

        anim.SetTrigger("Shoot");

        //JumpSound.Play();


        //rigid.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

    }
}

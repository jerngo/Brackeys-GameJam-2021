using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlue_Cont : MonoBehaviour
{
    public float walkSpeed = 1;
    public float jumpSpeed = 1;

    Rigidbody2D rigid;
    public Animator animWheel;
    public Animator animBody;
    //public AudioSource WalkSound;
    //public AudioSource JumpSound;

    AudioManager audiManager;
    //public GameObject dust;
    [SerializeField]
    bool isOnGround;
    [SerializeField]
    bool isCantMove;
    bool isJumping;

    [SerializeField]
    float jumpTimerCounter = 2;
    public float jumpTimer = 0.3f;
    void Start()
    {
        //smokeVFX.SetActive(false);
        rigid = this.GetComponent<Rigidbody2D>();
        isCantMove = false;
        audiManager = GetComponent<AudioManager>();
    }

    public bool DoFacingLeft()
    {
        return isFacingLeft;
    }

    private void Update()
    {
        if (transform.localScale.x > 0)
        {
            isFacingLeft = true;
        }
        else
        {
            isFacingLeft = false;
        }

        if (Mathf.Abs(rigid.velocity.y) < 0.001f && IsGrounded())
        {
            //anim.SetBool("OnGround", true);
            jumpTimerCounter = jumpTimer;
            isOnGround = true;
        }
        else
        {
            //anim.SetBool("OnGround", false);
            isOnGround = false;
        }
    }

    public GameObject smokeVFX;
    public void setCantMove(bool trigger)
    {
        isCantMove = trigger;

    }

    public void showSmoke()
    {
        //smokeVFX.SetActive(true);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isCantMove)
        {
            Movement();

            if (Input.GetButton("Jump") && isOnGround)
            {
                isJumping = true;
                Jump();
               // dust.SetActive(true);
            }

            if (Input.GetButton("Jump") && isJumping == true)
            {
                if (jumpTimerCounter > 0)
                {
                    if (isOnGround)
                    {
                        //dust.SetActive(true);
                        Jump();

                    }
                    rigid.velocity = Vector2.up * jumpSpeed;
                    jumpTimerCounter -= Time.deltaTime;
                }
                else
                {
                    //dust.SetActive(false);
                    isJumping = false;
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                // dust.SetActive(false);
                isJumping = false;
            }

        }

    }

    public LayerMask groundLayer;
    public LayerMask headLayer;
    // [SerializeField]
    float distance = 0.11f;
    //[SerializeField]
    float RayOffsetxL = 0.11f;
   // [SerializeField]
    float RayOffsetxR = 0.11f;
   // [SerializeField]
    float RayOffsetxM = -0.01f;
   // [SerializeField]
    float RayOffsetxMUp = 0f;
    //[SerializeField]
    float RayOffsetyUp = 0.25f;

    // [SerializeField]
    float RayOffsetxMUpL = -0.2f;
     //[SerializeField]
    float RayOffsetxMUpR = 0.2f;

    float RayOffsety = -0.59f;

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        //float distance = 1.0f;

        Debug.DrawRay(position + new Vector2(-RayOffsetxL, RayOffsety), direction * distance, Color.green);
        Debug.DrawRay(position + new Vector2(RayOffsetxR, RayOffsety), direction * distance, Color.red);
        Debug.DrawRay(position + new Vector2(RayOffsetxM, RayOffsety), direction * distance, Color.yellow);
        Debug.DrawRay(position + new Vector2(RayOffsetxMUp, RayOffsetyUp), direction * distance, Color.yellow);
        Debug.DrawRay(position + new Vector2(RayOffsetxMUpL, RayOffsetyUp), direction * distance, Color.yellow);
        Debug.DrawRay(position + new Vector2(RayOffsetxMUpR, RayOffsetyUp), direction * distance, Color.yellow);

        RaycastHit2D hit = Physics2D.Raycast(position + new Vector2(-RayOffsetxL, RayOffsety), direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(position + new Vector2(RayOffsetxR, RayOffsety), direction, distance, groundLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(position + new Vector2(RayOffsetxM, RayOffsety), direction, distance, groundLayer);
        RaycastHit2D hit4 = Physics2D.Raycast(position + new Vector2(RayOffsetxMUp, RayOffsetyUp), direction, distance, headLayer);
        RaycastHit2D hit5 = Physics2D.Raycast(position + new Vector2(RayOffsetxMUpL, RayOffsetyUp), direction, distance, headLayer);
        RaycastHit2D hit6 = Physics2D.Raycast(position + new Vector2(RayOffsetxMUpR, RayOffsetyUp), direction, distance, headLayer);
        if ((hit.collider != null || hit2.collider != null || hit3.collider != null) && (hit4.collider == null && hit5.collider == null && hit6.collider == null))
        {
            return true;
        }



        return false;
    }

    bool isFacingLeft = true;

    void Movement()
    {

        float horizontalAxis = Input.GetAxis("Horizontal");

        if (horizontalAxis != 0)
        {
            // if (WalkSound.enabled == true)
            //{
            //   if (WalkSound.isPlaying == false)
            //   {

            audiManager.PlayOnceAtATime("Walk");
              //  }
            //}

        }
        else
        {
            audiManager.Stop("Walk");
        }

        if (horizontalAxis < 0)
        {
            if (isFacingLeft == true)
            {
                Vector3 newScale = this.transform.localScale;
                newScale.x *= -1;
                this.transform.localScale = newScale;
                isFacingLeft = false;
            }

        }
        else if (horizontalAxis > 0)
        {
            if (isFacingLeft == false)
            {
                Vector3 newScale = this.transform.localScale;
                newScale.x *= -1;
                this.transform.localScale = newScale;
                isFacingLeft = true;
            }
        }



        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * walkSpeed;
        animWheel.SetFloat("Speed", Mathf.Abs(horizontalAxis));
        animBody.SetFloat("Speed", Mathf.Abs(horizontalAxis));





    }

    void Jump()
    {

        //DustPlay();

        animWheel.SetTrigger("Jump");
        animBody.SetTrigger("Jump");

        audiManager.Play("Jump");

        rigid.velocity = Vector2.up * jumpSpeed;



        //rigid.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

    }
}

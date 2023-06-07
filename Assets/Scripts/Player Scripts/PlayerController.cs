using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float gameSpeed;
    public float jumpStrength;
    public float jumpCount;
    public float maxSpeed = 4;

    public Transform groundCheckPos;

    AudioSource myAudioSource;
    public AudioClip DJAudio;
    public float volume;

    public bool jump = false;
    public bool canMove = true;
    public bool grounded = true;
    public bool inWater = false;

    public Rigidbody2D playerRb;

    public BloodCollection bloodCollect;

    public LayerMask groundLayer;

    public GameObject mySprite;
    public Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        gameSpeed = 1;
        jumpStrength = 29;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        bloodCollect = gameObject.GetComponent<BloodCollection>();

        myAudioSource = GetComponent<AudioSource>();
        myAnimator = mySprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove == true)
        {
            horizontalInput = Input.GetAxis("Horizontal") * speed;
            horizontalInput = Mathf.Clamp(horizontalInput, -maxSpeed, maxSpeed);
            if (Mathf.Abs(horizontalInput) >= maxSpeed - 1)
            {
                transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed * gameSpeed);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && canMove == true)
        {
            if(bloodCollect.DJumpUS == 0 && grounded == true || bloodCollect.DJumpUS == 0 && inWater == true)
            {
                jump = true;
            }
            else if(bloodCollect.DJumpUS == 1 && jumpCount > 0)
            {
                jump = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if(jump == true)
        {
            myAudioSource.PlayOneShot(DJAudio, volume);
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(Vector2.up * jumpStrength * gameSpeed, ForceMode2D.Impulse);
            jumpCount -= 1;
            jump = false;
            Debug.Log("fixed");
        }
        if(!Physics2D.OverlapCircle(groundCheckPos.position, .01f, groundLayer))
        {
            grounded = false;
        }
        else
        {
            grounded = true;

            if (bloodCollect.DJumpUS == 1)
            {
                jumpCount = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Water")
        {
            //maxSpeed = 5;
            inWater = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            //maxSpeed = 1;
            inWater = true;
            jumpCount = 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            Debug.Log("slowdown");
            //maxSpeed = 1;
            inWater = true;
        }
    }
}

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

    public bool jump = false;
    public bool canMove = true;
    public bool grounded = true;
    bool inWater = false;

    public Rigidbody2D playerRb;

    public BloodCollection bloodCollect;

    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        gameSpeed = 1;
        jumpStrength = 29;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        bloodCollect = gameObject.GetComponent<BloodCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            horizontalInput = Input.GetAxis("Horizontal") * speed;
            horizontalInput = Mathf.Clamp(horizontalInput, -maxSpeed, maxSpeed);
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed * gameSpeed);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            maxSpeed = 3;
            inWater = true;
            jumpCount = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            maxSpeed = 5;
            inWater = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Water")
        {
            Debug.Log("slowdown");
            maxSpeed = 3;
            inWater = true;
        }
    }
}

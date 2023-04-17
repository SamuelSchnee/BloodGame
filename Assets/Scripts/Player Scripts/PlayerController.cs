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

    public Transform groundCheckPos;

    public bool jump = false;
    public bool canMove = true;
    public bool grounded = true;
    
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
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed * gameSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canMove == true /*&& grounded == true jumpCount > 0*/)
        {
            if(bloodCollect.DJumpUS == 0 && grounded == true)
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
}

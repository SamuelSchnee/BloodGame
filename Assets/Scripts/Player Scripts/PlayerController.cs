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

    public bool jump = false;

    public Rigidbody2D playerRb;

    public CharacterController2D controller;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        gameSpeed = 1;
        jumpStrength = 20;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed * gameSpeed);

        /*if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            jump = true;
            //transform.Translate(new Vector3(0, jumpStrength, 0) * Time.deltaTime);
            //playerRb.AddForce(Vector2.up * jumpStrength * gameSpeed);
        }
    }
    private void FixedUpdate()
    {
        if(jump == true)
        {
            playerRb.AddForce(Vector2.up * jumpStrength * gameSpeed, ForceMode2D.Impulse);
            jump = false;
            Debug.Log("fixed");
        }

        //controller.Move(horizontalInput * Time.fixedDeltaTime, false, jump);
        //jump = false;
    }
}

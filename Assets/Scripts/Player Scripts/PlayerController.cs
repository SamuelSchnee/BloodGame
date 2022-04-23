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

    private Rigidbody2D playerRb;

    public CharacterController2D controller;

    // Start is called before the first frame update
    void Start()
    {
        speed = 50;
        gameSpeed = 1;
        jumpStrength = 900;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * gameSpeed * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump");
            //transform.Translate(new Vector3(0, jumpStrength, 0) * Time.deltaTime);
            playerRb.AddForce(Vector2.up * jumpStrength * gameSpeed);
        }*/
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalInput * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamAbility : Ability
{
    Rigidbody2D playerBody;
    public LayerMask groundLayer;
    public Collider2D groundDetector;
    public bool grounded;
    public float slamSpeed;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groundDetector.IsTouchingLayers(groundLayer))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if(cooldown >= 0)
        {
            cooldown -= cooldownSpeed;
        }
        if(cooldown <= 0)
        {
            readyToUse = true;
        }

        if(grounded == false && Input.GetKeyDown(KeyCode.Alpha1) && readyToUse == true)
        {
            playerBody.velocity = Vector2.zero;
            playerBody.AddForce(Vector2.down * slamSpeed, ForceMode2D.Impulse);
            readyToUse = false;
            cooldown = cooldownLength;
        }
    }
}

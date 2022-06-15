using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    public bool dashing;
    public float dashDistance;
    public PlayerController playerCnt;
    public Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCnt = GetComponent<PlayerController>();
        cooldownLength = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            readyToUse = true;
        }
        else
        {
            readyToUse = false;
            cooldown -= .5f;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && readyToUse == true)
        {
            //dashing = true;
            /* playerCnt.canMove = false;
             transform.position = new Vector2(transform.position.x + dashDistance, transform.position.y);
             playerCnt.canMove = true;
             cooldown = cooldownLength;
             Debug.Log("dashing");*/
            StartCoroutine(Dash());
        }

        /*if(dashing == true)
        {
            playerCnt.canMove = false;
            readyToUse = false;
            Invoke("Dash", 2);
        }*/
    }

    IEnumerator Dash()
    {
        readyToUse = false;
        playerCnt.canMove = false;
        playerBody.gravityScale = 0;
        playerBody.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(.25f);
        transform.position = new Vector2(transform.position.x + dashDistance, transform.position.y);
        yield return new WaitForSecondsRealtime(.2f);
        playerCnt.canMove = true;
        playerBody.gravityScale = 3;
        cooldown = cooldownLength;
    }
    /*void Dash()
    {
        
        playerCnt.canMove = true;
        dashing = false;
        cooldown = cooldownLength;
        transform.position = new Vector2(transform.position.x + dashDistance, transform.position.y);
    }*/
}

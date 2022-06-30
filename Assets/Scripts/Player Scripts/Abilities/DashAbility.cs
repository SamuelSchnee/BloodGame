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
            cooldown -= cooldownSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && readyToUse == true)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        readyToUse = false;
        playerCnt.canMove = false;
        playerBody.gravityScale = 0;
        playerBody.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(.1f);
        transform.position = new Vector2(transform.position.x + dashDistance, transform.position.y);
        yield return new WaitForSecondsRealtime(.1f);
        playerCnt.canMove = true;
        playerBody.gravityScale = 3;
        cooldown = cooldownLength;
    }
}

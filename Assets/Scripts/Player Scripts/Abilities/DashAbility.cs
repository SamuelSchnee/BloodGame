using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    public Rigidbody2D playerRb;
    public bool dashing;
    Vector2 dashDistance;
    public PlayerController playerCnt;

    public Transform dashDestination;

    // Start is called before the first frame update
    void Start()
    {
        playerCnt = GetComponent<PlayerController>();
        playerRb = GetComponent<Rigidbody2D>();
        cooldownLength = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownLength <= 0)
        {
            readyToUse = true;
        }

        if(Input.GetKeyDown(KeyCode.Tab) && readyToUse == true)
        {
            dashing = true;
        }

        if(dashing == true)
        {
            playerCnt.canMove = false;
            Invoke("Dash", 2);
        }
    }

    private void Dash()
    {

       // transform.position += (5, 0);
        dashing = false;
        playerCnt.canMove = true;
    }
}

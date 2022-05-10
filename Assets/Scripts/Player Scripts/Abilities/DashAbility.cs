using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : Ability
{
    public Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        cooldownLength = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && readyToUse == true)
        {
            playerRb.velocity = Vector2.zero;
        }
    }

    private void Dash()
    {
        
    }
}

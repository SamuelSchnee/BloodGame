using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDash : Ability
{
    Rigidbody2D playerBody;
    public Vector2 dashForce = new Vector2(20, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            readyToUse = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && readyToUse == true)
        {
            Debug.Log("hitting shift");
            Dash();
        }
    }

    private void Dash()
    {
        Debug.Log("dashing");
        playerBody.velocity = Vector2.zero;
        playerBody.gravityScale = 0;
        playerBody.AddForce(dashForce, ForceMode2D.Impulse);
        Invoke("Stun", .5f);
    }

    void Stun()
    {
        playerBody.gravityScale = 3;
    }
}

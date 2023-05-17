using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDJEnemy : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D myRB;
    public Rigidbody2D playerRB;
    public Health playerHealth;
    public float targetBounds = 5;
    public float jumpStrength = 5;
    public float launchStrength;

    float cooldown;
    public float maxCooldown;
    public Transform groundCheck;
    public LayerMask groundLayers;
    bool grounded;
    public float damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > transform.position.y && player.transform.position.x > transform.position.x - targetBounds 
        && player.transform.position.x < transform.position.x + targetBounds && cooldown <= 0)
        {
            myRB.velocity = new Vector2(0, jumpStrength);
            cooldown = maxCooldown;
        }

        if(cooldown > 0 && grounded == true)
        {
            cooldown -= Time.deltaTime;
        }

        if (myRB.IsTouchingLayers(groundLayers))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && grounded == false)
        {
            playerHealth = other.gameObject.GetComponent<Health>();
            playerRB = other.gameObject.GetComponent<Rigidbody2D>();

            playerHealth.TakeDamage(damage);

            playerRB.velocity = new Vector2(0, launchStrength);
        }
    }
}

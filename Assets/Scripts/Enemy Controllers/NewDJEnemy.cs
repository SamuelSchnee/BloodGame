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
    public bool canAttack= true;

    Animator myAnimator;

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
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > transform.position.y && player.transform.position.x > transform.position.x - targetBounds 
        && player.transform.position.x < transform.position.x + targetBounds && cooldown <= 0)
        {
            myRB.velocity = new Vector2(0, jumpStrength);
            cooldown = maxCooldown;
            canAttack = true;
        }

        if(cooldown > 0 && grounded == true)
        {
            cooldown -= Time.deltaTime;
        }

        if (myRB.IsTouchingLayers(groundLayers))
        {
            grounded = true;
            myAnimator.SetBool("InAir", false);
            //InAir
        }
        else
        {
            grounded = false;
            myAnimator.SetBool("InAir", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && grounded == false && canAttack == true)
        {
            canAttack = false;
            playerHealth = other.gameObject.GetComponent<Health>();
            playerRB = other.gameObject.GetComponent<Rigidbody2D>();

            playerHealth.TakeDamage(damage);

            playerRB.velocity = new Vector2(0, launchStrength);
            Debug.Log("hit player");
        }
    }
}

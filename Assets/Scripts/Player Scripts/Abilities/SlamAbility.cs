using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamAbility : Ability
{
    Rigidbody2D playerBody;
    public PlayerController playerCnt;
    public LayerMask groundLayer;
    public Collider2D groundDetector;
    public bool grounded;
    public float slamSpeed;
    public bool slamming;
    public float stunTime = .25f;

    public Transform slamHitbox;
    public float hitboxSize;
    public LayerMask enemyLayers;
    private Health enemyHealth;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCnt = GetComponent<PlayerController>();
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
            Slam();
        }

        if(slamming == true && grounded == true)
        {
            HitboxActive();
        }
    }

    void Slam()
    {
        playerBody.velocity = Vector2.zero;
        playerBody.AddForce(Vector2.down * slamSpeed, ForceMode2D.Impulse);
        slamming = true;
        readyToUse = false;
        cooldown = cooldownLength;
        playerCnt.canMove = false;
        Invoke("Stun", stunTime);
    }

    void Stun()
    {
        playerCnt.canMove = true;
    }

    void HitboxActive()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(slamHitbox.position, hitboxSize, enemyLayers);
        
        if (slamming == true)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("slammed " + enemy);
                enemyHealth = enemy.GetComponent<Health>();
                enemyHealth.TakeDamage(damage);
                slamming = false;
            }
        }

        if (hitEnemies.Length == 0)
        {
            slamming = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(slamHitbox.position, hitboxSize);
    }
}

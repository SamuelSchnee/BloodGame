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
    public bool slamming;

    public Transform slamHitbox;
    public float hitboxSize;
    public LayerMask enemyLayers;
    private Health enemyHealth;

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
            Slam();
        }

        if(slamming == true && grounded == false)
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
    }

    void HitboxActive()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(slamHitbox.position, hitboxSize, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("slammed " + enemy);
            enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
        slamming = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(slamHitbox.position, hitboxSize);
    }
}

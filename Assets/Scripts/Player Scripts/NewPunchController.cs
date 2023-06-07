using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPunchController : Ability
{
    public bool animate;
    public Transform punchHitbox;
    public LayerMask enemyLayers;
    public float hitboxSize = .5f;
    public Health enemyHealth;

    public float maxCooldown = 1;
    public float myCooldown;

    public float attackRate = 2f;
    public float nextAttackTime = 0;

    public GameObject mySprite;
    Animator myAnimator;

    private void Start()
    {
        myAnimator = mySprite.GetComponent<Animator>();
        myCooldown = 0;
    }

    void Update()
    {
        if(myCooldown >= 0)
        {
            myCooldown -= Time.deltaTime;
        }

        if(myCooldown < .5f)
        {
            myAnimator.SetBool("Punching", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (myCooldown <= 0)
            {
                myAnimator.SetBool("Punching", true);
                Attack();
                Debug.Log("check");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if(nextAttackTime <= 2)
        {
           myAnimator.SetBool("Punching", false);
        }

        if(animate == true)
        {
            //myAnimator.SetBool("Punching", false);
            Debug.Log("check2");
            animate = false;
        }
    }

    private void Attack()
    {
       Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(punchHitbox.position, hitboxSize, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("we hit" + enemy.name);
            enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
        animate = true;
        myCooldown = maxCooldown;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchHitbox.position, hitboxSize);
    }
}

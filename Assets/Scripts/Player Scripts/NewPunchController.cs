using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPunchController : Ability
{
    public Transform punchHitbox;
    public LayerMask enemyLayers;
    public float hitboxSize = .5f;
    public Health enemyHealth;

    public float attackRate = 2f;
    float nextAttackTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(punchHitbox.position, hitboxSize);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamAbility : Ability
{
    /// <Make sure to eventually make all abilities child classes of Ability script. Look at line 5>
    /// //////////////////////////////////////////      
    /// </summary>
    public Transform leftHitbox;
    public Transform rightHitbox;
    public GameObject breakableGround;

    public LayerMask enemyLayers;
    public LayerMask groundLayers;

    public float hitboxSize = .5f;
    public float maxCooldown = 1;

    public Health enemyHealth;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && cooldown <= 0)
        {
            Slam();
            cooldown = maxCooldown;
        }

        if(cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    void Slam()
    {
        Debug.Log("slam");
        Collider2D[] hitEnemyLeft = Physics2D.OverlapCircleAll(leftHitbox.position, hitboxSize, enemyLayers);
        foreach (Collider2D enemy in hitEnemyLeft)
        {
            enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
        Collider2D[] hitEnemyRight = Physics2D.OverlapCircleAll(rightHitbox.position, hitboxSize, enemyLayers);
        foreach (Collider2D enemy in hitEnemyRight)
        {
            enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
        /*Collider2D[] groundBreak = Physics2D.OverlapCircleAll(groundBreaker.position, hitboxSize + 1, groundLayers);
        foreach (Collider2D ground in groundBreak)
        {
            Debug.Log("ground Found");
            if(ground.tag == "Breakable")
            {
                Destroy(ground.gameObject);
            }
        }*/

        if(breakableGround != null)
        {
            Destroy(breakableGround);
        }
    }
}

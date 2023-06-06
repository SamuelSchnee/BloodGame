using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamEnemyController : MonoBehaviour
{
    public bool targetFound;
    public FlyingEnemyPathing pathing;
    public Rigidbody2D enemyrb;

    public LayerMask groundLayer;
    public GameObject groundDetector;
    public Collider2D groundBody;

    public GameObject player;

    public bool attacking = false;
    public bool doneAttacking = false;

    public Transform enemyReturn;

    public float hitboxSize;
    public LayerMask playerLayer;
    public Health playerHealth;
    public float damage;
    public bool plzAttack = false;

    public float cooldown;
    public float maxcooldown;
    public float attackRange = 2;

    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
        groundBody = groundDetector.GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
            targetFound = false;
        }

        if(cooldown <= 0 && doneAttacking == false)
        {
            if(player.transform.position.x <= transform.position.x + attackRange && player.transform.position.x >= transform.position.x - attackRange)
            {
                targetFound = true;
            }
        }

        if (targetFound == true && doneAttacking == false && cooldown <= 0)
        {
            pathing.mustPatorl = false;
            enemyrb.velocity = Vector2.zero;
            StartCoroutine(Slam());
        }
        if (doneAttacking == true)
        {
            AfterAttacking();
        }
        if(plzAttack == true)
        {
            Debug.Log("plz attack");
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(transform.position, hitboxSize, playerLayer);

            if (hitPlayer != null && attacking == true && doneAttacking == false)
            {
                foreach (Collider2D player in hitPlayer)
                {
                    Debug.Log("player Hit");
                    playerHealth = player.GetComponent<Health>();
                    playerHealth.TakeDamage(damage);
                }
            }

            Debug.Log("no target hit");
            doneAttacking = true;
            targetFound = false;
            attacking = false;
            plzAttack = false;
        }
    }

    private void AfterAttacking()
    {
        if(transform.position.y < enemyReturn.transform.position.y)
        {
            enemyrb.velocity = new Vector2(0, 20);
        }
        if(transform.position.y >= enemyReturn.transform.position.y)
        {
            cooldown = maxcooldown;
            enemyrb.velocity = Vector2.zero;
            pathing.mustPatorl = true;
            Debug.Log("returnToPathing");
            doneAttacking = false;
        }
    }

    IEnumerator Slam()
    {
        yield return new WaitForSecondsRealtime(.2f);
        enemyrb.velocity = new Vector2(0, -30);

        if (groundBody.IsTouchingLayers(groundLayer))
        {
            enemyrb.velocity = Vector2.zero;
            attacking = true;
            plzAttack = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, hitboxSize);
    }
}

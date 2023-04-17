using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public bool mustPatrol;
    private bool mustTurn;

    public float moveSpeed;
    public float attackRange;
    private float distToPlayer;

    public Rigidbody2D enemyRb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Transform wallCheckPos;
    public Transform player;
    public float enemyDetectionRange = 3;

    public EnemyShoot enShoot;

    void Start()
    {
        mustPatrol = true;
        enemyRb = GetComponent<Rigidbody2D>();
        enShoot = gameObject.GetComponent<EnemyShoot>();
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= attackRange)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0 
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            mustPatrol = false;
            enemyRb.velocity = Vector2.zero;
            Shoot();
        }
        else
        {
            mustPatrol = true;
            enShoot.shooting = false;
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, .1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn || Physics2D.OverlapCircle(wallCheckPos.position, .1f, groundLayer))
        {
            Flip();
        }
        enemyRb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, enemyRb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
        mustPatrol = true;
    }

    void Shoot()
    {
        enShoot.shooting = true;
    }
}

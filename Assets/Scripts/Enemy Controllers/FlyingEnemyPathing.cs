using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyPathing : MonoBehaviour
{
    public bool mustPatorl;
    public bool mustTurn;

    public float moveSpeed;

    public Rigidbody2D enemyRb;
    public Transform rightMostPoint;
    public Transform leftMostPoint;
    public Transform flightChecker;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        mustPatorl = true;
    }

    void Update()
    {
        if (mustPatorl)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatorl)
        {
            if (flightChecker.transform.position.x < rightMostPoint.transform.position.x || flightChecker.transform.position.x > leftMostPoint.transform.position.x)
            {
                mustTurn = true;
            }
        }
    }

    void Patrol()
    {
        if (mustTurn == true)
        {
            Flip();
        }
        enemyRb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, enemyRb.velocity.y);
    }

    void Flip()
    {
        mustPatorl = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        moveSpeed *= -1;
        mustTurn = false;
        mustPatorl = true;
    }
}

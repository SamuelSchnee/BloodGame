using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject target;
    public float damage;
    public float bulletLife = 1;

    public Vector2 targetLocation;
    public Vector2 bulletLocation;
    public Vector2 targetDirection;
    public float distFromTarget;

    private bool targetFound;

    private Rigidbody2D bulletRb;

    public float bulletSpeed = 1f;
    public Health enemyhealth;

    void Start()
    {
        distFromTarget = 3;
        bulletRb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    void Update()
    {
        bulletLocation = gameObject.transform.position;

        if (target != null)
        {
            //bulletRb.velocity = Vector2.zero;
            distFromTarget = Mathf.Sqrt(Mathf.Pow(bulletLocation.x - targetLocation.x, 2) + Mathf.Pow(bulletLocation.y - targetLocation.y, 2));
            Debug.Log("target transfered");
            trackingTarget();
        }


    }

    private void trackingTarget()
    {
        targetLocation = target.transform.position;

        targetDirection = targetLocation - bulletLocation;
        targetDirection.Normalize();

        

        targetDirection *= bulletSpeed;

        bulletRb.AddForce(targetDirection, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && distFromTarget < 2f)
        {
            Debug.Log("hitEnemy");
            enemyhealth = collision.gameObject.GetComponent<Health>();
            enemyhealth.TakeDamage(damage);
            Destroy(this.gameObject);
            Debug.Log("destroyed");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && distFromTarget < 2f)
        {
            Debug.Log("hitEnemy");
            enemyhealth = collision.gameObject.GetComponent<Health>();
            enemyhealth.TakeDamage(damage);
            Destroy(this.gameObject);
            Debug.Log("destroyed");
        }
    }
}

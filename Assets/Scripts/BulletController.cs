using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject target;

    public Vector2 targetLocation;
    public Vector2 bulletLocation;
    public Vector2 targetDirection;

    private bool targetFound;

    private Rigidbody2D bulletRb;

    public float bulletSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletLocation = gameObject.transform.position;

        if (target != null)
        {
            Debug.Log("target transfered");
            trackingTarget();
        }
    }

    private void trackingTarget()
    {
        targetLocation = target.transform.position;

        targetDirection = targetLocation - bulletLocation;
        targetDirection.Normalize();

        bulletRb.velocity = Vector2.zero;

        targetDirection *= bulletSpeed;

        bulletRb.AddForce(targetDirection, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}

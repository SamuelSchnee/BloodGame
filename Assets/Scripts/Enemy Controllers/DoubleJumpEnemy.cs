using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpEnemy : MonoBehaviour
{
    public Rigidbody2D enemyBody;
    public GameObject target;
    public Collider2D enemyCollider;
    public GameObject target0, target1, target2, target3, target4;
    public float speed, pause;
    public string state;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
        state = "waiting";
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "initialDash")
        {
            Invoke("InitialDash", pause);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && state == "waiting")
        {
            target = other.gameObject;
            state = "initialDash";
        }
    }

    void InitialDash()
    {
        GameObject destination = target0;
        enemyBody.gravityScale = 0;
        Vector3 direction = destination.transform.position - transform.position;
        direction *= Time.deltaTime;
        direction *= speed;

        if(transform.position != destination.transform.position)
        {
            transform.position += direction;
        }
        else
        {
            state = "secondaryDash";
        }
    }

    void FindingEnemy()
    {
        if(target.transform.position.y < transform.position.y && target.transform.position.x < transform.position.x)
        {
            target = target1;
            state = "secondaryDash";
        }
        else if(target.transform.position.y > transform.position.y && target.transform.position.x < transform.position.x)
        {
            target = target2;
            state = "secondaryDash";
        }
        else if(target.transform.position.y > transform.position.y && target.transform.position.x > transform.position.x)
        {
            target = target3;
            state = "secondaryDash";
        }
        else if(target.transform.position.y < transform.position.y && target.transform.position.x > transform.position.x)
        {
            target = target4;
            state = "secondaryDash";
        }

    }

    void SecondaryDash(GameObject destination)
    {

    }
}

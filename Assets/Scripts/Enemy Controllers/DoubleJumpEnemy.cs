using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoubleJumpEnemy : MonoBehaviour
{
    public Rigidbody2D enemyBody;
    public GameObject target, destination;
    public Collider2D enemyCollider;
    public GameObject target0, target1, target2, target3, target4;
    public float speed, pause;
    public string state;
    private SpriteRenderer sprite;

    public UnityEvent OnDoneAttacking;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        enemyBody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
        state = "hiding";
        Invoke("Hiding", 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(state == "initialDash")
        {
            Invoke("InitialDash", pause);
        }
        else if(state == "findingEnemy")
        {
            Invoke("FindingEnemy", .5f);
        }
        else if(state == "secondaryDash")
        {
            Invoke("SecondaryDash", 0);
        }
        else if(state == "doneAttacking")
        {
            Invoke("DoneAttacking", .25f);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && state == "hiding")
        {
            Debug.Log("GettingCalled");
            target = other.gameObject;
            Invoke("Reveal", .25f);
        }
    }

    void Hiding()
    {
        Debug.Log("Hiding");
        enemyBody.gravityScale = 0;
        enemyCollider.enabled = false;
        sprite.enabled = false;
    }

    void Reveal()
    {
        Debug.Log("Reveal");
        enemyBody.gravityScale = 5;
        enemyCollider.enabled = true;
        sprite.enabled = true;
        Invoke("InitialDash", .5f);
        state = "reveal";
    }


    void InitialDash()
    {
        Debug.Log("initialDash");
        destination = target0;
        enemyBody.gravityScale = 0;

        //finds direction of central point and sends character to it over time
        //doesn't work due to the fact that it has a chance of never hitting the exact point
        /*Vector3 direction = destination.transform.position - transform.position;
        direction.Normalize();
        direction *= speed;*/

        transform.position = destination.transform.position;
        Invoke("FindingEnemy", .5f);
        //state = "findingEnemy";

        //moves the target and then changes the state
       /* if(transform.position != destination.transform.position)
        {
            transform.position += direction;
        }
        else
        {
            state = "findingEnemy";
        }*/
    }

    void FindingEnemy()
    {
        Debug.Log("FindingEnemy");
        if (target.transform.position.y < transform.position.y && target.transform.position.x < transform.position.x)
        {
            destination = target1;
            Invoke("SecondaryDash", .5f);
        }
        else if(target.transform.position.y > transform.position.y && target.transform.position.x < transform.position.x)
        {
            destination = target2;
            Invoke("SecondaryDash", .5f);
        }
        else if(target.transform.position.y > transform.position.y && target.transform.position.x > transform.position.x)
        {
            destination = target3;
            Invoke("SecondaryDash", .5f);
        }
        else if(target.transform.position.y < transform.position.y && target.transform.position.x > transform.position.x)
        {
            destination = target4;
            Invoke("SecondaryDash", .5f);
        }

    }

    void SecondaryDash()
    {
        Debug.Log("Secondary Dash");
        /*Vector3 direction = destination.transform.position - transform.position;
        direction.Normalize();
        direction *= speed;

        if (transform.position != destination.transform.position)
        {
            Debug.Log("Moving SD");
            transform.position += direction;
        }*/

        transform.position = destination.transform.position;
        Invoke("DoneAttacking", .5f);
    }

    void DoneAttacking()
    {
        Debug.Log("DoneAttacking");
        enemyBody.gravityScale = 5;
        OnDoneAttacking.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fistController : MonoBehaviour
{
    public float damage;
    public Health enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("punch");
            enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("punched");
            enemyHealth = collision.gameObject.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);

        }
    }
}

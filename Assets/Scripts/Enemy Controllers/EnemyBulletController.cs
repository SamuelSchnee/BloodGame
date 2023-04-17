using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Health targetHealth;
    public float damage;
    public float bulletLife = 5;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetHealth = other.gameObject.GetComponent<Health>();
            targetHealth.TakeDamage(damage);
            Debug.Log("player hit");
            Destroy(this.gameObject);
        }
    }
}

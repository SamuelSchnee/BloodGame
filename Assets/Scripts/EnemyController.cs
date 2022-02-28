using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public BulletController bulletController;
    private Rigidbody2D playerRB;
    public float moveSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // playerRB.AddForce(Vector2.left * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
        }
    }
}

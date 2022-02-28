using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject spawner;

    public float bulletSpeed = 100;

    private PlayerController playerCnt;

    private Rigidbody2D bulletRB;

    public Vector2 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawnerPos = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
        Vector2 direction = mousePos - spawnerPos;
        bulletRB.velocity = direction * bulletSpeed;
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //bulletRB.AddForce(Vector2.right * bulletSpeed * Time.deltaTime);


        //shootDirection = Input.mousePosition;
        //shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);

        /*if (target != null)
        {
            followTarget();
        }*/
    }

    /*void followTarget()
    {
        Vector3 targetPosition = target.transform.position;
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * bulletSpeed);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("enemyHit");
            Destroy(this.gameObject);
        }
    }
}

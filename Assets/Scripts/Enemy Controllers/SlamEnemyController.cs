using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamEnemyController : MonoBehaviour
{
    public bool targetFound;
    public FlyingEnemyPathing pathing;
    public Rigidbody2D enemyrb;

    public LayerMask groundLayer;
    public GameObject groundDetector;
    public Collider2D groundBody;

    public GameObject hitbox1;
    public GameObject hitbox2;

    public bool attacking = false;
    public bool doneAttacking = false;

    public Transform enemyReturn;

    bool test;

    // Start is called before the first frame update
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
        groundBody = groundDetector.GetComponent<Collider2D>();
        hitbox1.SetActive(false);
        test = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetFound == true && doneAttacking == false)
        {
            pathing.mustPatorl = false;
            enemyrb.velocity = Vector2.zero;
            StartCoroutine(Slam());
        }
        if (doneAttacking == true)
        {
            AfterAttacking();
        }
    }

    private void AfterAttacking()
    {
        if(transform.position.y < enemyReturn.transform.position.y)
        {
            enemyrb.velocity = new Vector2(0, 20);
        }
        if(transform.position.y >= enemyReturn.transform.position.y)
        {
            enemyrb.velocity = Vector2.zero;
            pathing.mustPatorl = true;
            Debug.Log("returnToPathing");
            doneAttacking = false;
        }
    }

    IEnumerator Slam()
    {
        yield return new WaitForSecondsRealtime(.2f);
        enemyrb.velocity = new Vector2(0, -30);

        if (groundBody.IsTouchingLayers(groundLayer))
        {
            enemyrb.velocity = Vector2.zero;
            attacking = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        if (attacking == true && doneAttacking == false)
        {
            hitbox1.SetActive(true);
            yield return new WaitForSecondsRealtime(.1f);
            hitbox1.SetActive(false);
            doneAttacking = true;
            targetFound = false;
            attacking = false;
        }
    }
}

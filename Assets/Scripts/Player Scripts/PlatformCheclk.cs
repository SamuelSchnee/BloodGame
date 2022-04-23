using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheclk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            Debug.Log("colliding");
            Collider2D platformCollider = other.gameObject.GetComponent<Collider2D>();
            platformCollider.isTrigger = false;

            if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
            {
                platformCollider.isTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            Collider2D platformCollider = collision.gameObject.GetComponent<Collider2D>();
            platformCollider.isTrigger = true;
        }
    }
}

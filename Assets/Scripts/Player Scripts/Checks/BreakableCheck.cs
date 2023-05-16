using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableCheck : MonoBehaviour
{
    public SlamAbility slam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        slam = player.GetComponent<SlamAbility>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Breakable")
        {
            slam.breakableGround = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Breakable")
        {
            slam.breakableGround = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject player;
    public GameObject djEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTargets()
    {
        transform.position = djEnemy.transform.position;

        if(player.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        else if(player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject mountains, forest, player;
    public float vertOffset = 5;
    public bool inMountains, inForest;
    // Start is called before the first frame update
    void Start()
    {
        inMountains = true;
        inForest = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(inMountains == true && mountains != null)
        {
            mountains.SetActive(true);
            mountains.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + vertOffset);
        }
        else
        {
            mountains.SetActive(false);
        }

        if (forest != null)
        {
            if (inForest == true)
            {
                forest.SetActive(true);
                forest.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + vertOffset);
            }
            else
            {
                forest.SetActive(false);
            }
        }
    }
}

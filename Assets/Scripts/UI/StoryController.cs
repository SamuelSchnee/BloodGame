using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public int spitterKilled, frogKilled, flyKilled, crusherKilled;
    public GameObject[] allGrass;

    public GameObject[] cleanPools;
    public GameObject[] dirtyPools;

    public GameObject fog;

    public GameObject[] moss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spitterKilled >= 5)
        {
            foreach(GameObject grass in allGrass)
            {
                grass.SetActive(true);
            }
        }

        if(frogKilled >= 4)
        {
            foreach(GameObject water in cleanPools)
            {
                water.SetActive(false);
            }
            foreach(GameObject water in dirtyPools)
            {
                water.SetActive(true);
            }
        }
        if(flyKilled >= 5)
        {
            fog.SetActive(true);
        }

        if(crusherKilled >= 4)
        {
            foreach(GameObject moss in moss)
            {
                moss.SetActive(true);
            }
        }
    }

    public void ProgressStory(string enemy)
    {
        if(enemy == "Spitter")
        {
            spitterKilled++;
        }
        else if(enemy == "Frog")
        {
            frogKilled++;
        }
        else if(enemy == "Fly")
        {
            flyKilled++;
        }
        else if(enemy == "Crusher")
        {
            crusherKilled++;
        }
    }
}

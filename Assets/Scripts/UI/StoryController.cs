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

    }

    public void ProgressStory(string enemy)
    {
        if(enemy == "spitter")
        {
            spitterKilled++;
        }
        else if(enemy == "frog")
        {
            frogKilled++;
        }
        else if(enemy == "fly")
        {
            flyKilled++;
        }
        else if(enemy == "crusher")
        {
            crusherKilled++;
        }
    }

    public void UpdateStory()
    {
        if (spitterKilled >= 5)
        {
            foreach (GameObject grass in allGrass)
            {
                grass.SetActive(true);
            }
        }

        if (frogKilled >= 4)
        {
            foreach (GameObject water in cleanPools)
            {
                water.SetActive(false);
            }
            foreach (GameObject water in dirtyPools)
            {
                water.SetActive(true);
            }
        }
        if (flyKilled >= 5)
        {
            fog.SetActive(true);
        }

        if (crusherKilled >= 4)
        {
            foreach (GameObject moss in moss)
            {
                moss.SetActive(true);
            }
        }
    }
}

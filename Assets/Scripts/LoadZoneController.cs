using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZoneController : MonoBehaviour
{
    public GameObject desiredLocation;
    public bool goingToForest, goingToPlains;
    public GameObject controller;
    public BackgroundController backgroundCntlr;

    public GameObject storyMaster;
    public StoryController story;

    private void Start()
    {
        backgroundCntlr = controller.GetComponent<BackgroundController>();
        storyMaster = GameObject.FindGameObjectWithTag("Story");
        story = storyMaster.GetComponent<StoryController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (desiredLocation != null)
            {
                Debug.Log("moving player");
                other.transform.position = desiredLocation.transform.position;
                story.UpdateStory();
            }
            if(goingToForest == true)
            {
                backgroundCntlr.inForest = true;
                backgroundCntlr.inMountains = false;
            }
            if (goingToPlains == true)
            {
                backgroundCntlr.inMountains = true;
                backgroundCntlr.inForest = false;
            }
        }
    }
}

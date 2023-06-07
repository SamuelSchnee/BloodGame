using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject mountains, forest, player, activeBackground;
    public float vertOffset = 5;
    public bool inMountains, inForest;
    public GameObject myCamera;
    public CameraController cameraController;
    public GameObject fog;

    public AudioSource myAudio1;
    public AudioSource myAudio2;
    public bool startMusic;

    // Start is called before the first frame update
    void Start()
    {
        inMountains = true;
        activeBackground = mountains;
        inForest = false;
        player = GameObject.FindGameObjectWithTag("Player");
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraController = myCamera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        fog.transform.position = player.transform.position;

        if(cameraController.freezeCamera == false)
        {
            activeBackground.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + vertOffset);
        }
        else if(cameraController.freezeCamera == true)
        {
            activeBackground.transform.position = new Vector2(activeBackground.transform.position.x, player.transform.position.y + vertOffset);
        }

        if(inMountains == true && mountains != null)
        {
            mountains.SetActive(true);
            activeBackground = mountains;
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
                activeBackground = forest;
            }
            else
            {
                forest.SetActive(false);
            }
        }
    }
    public void StartForestMusic()
    {
        myAudio2.Play();
        myAudio1.Stop();
    }
    public void StartPlainsMusic()
    {
        myAudio1.Play();
        myAudio2.Stop();
    }
}

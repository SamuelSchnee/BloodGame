using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public float CameraVertOffset;

    public bool freezeCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeCamera == false)
        {
            transform.position = new Vector3(PlayerCharacter.transform.position.x, PlayerCharacter.transform.position.y + CameraVertOffset, -10);
        }
        if(freezeCamera == true)
        {
            transform.position = new Vector3(transform.position.x, PlayerCharacter.transform.position.y + CameraVertOffset, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            freezeCamera = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "FreezeCamera")
        {
            freezeCamera = false;
        }
    }
}

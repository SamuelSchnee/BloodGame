using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCamera : MonoBehaviour
{
    public GameObject myCamera;
    public CameraController cameraCntrl;
    // Start is called before the first frame update
    void Start()
    {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraCntrl = myCamera.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraCntrl.freezeCamera = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraCntrl.freezeCamera = false;
        }
    }
}

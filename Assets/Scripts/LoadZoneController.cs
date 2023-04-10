using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZoneController : MonoBehaviour
{
    public GameObject desiredLocation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (desiredLocation != null)
            {
                Debug.Log("moving player");
                other.transform.position = desiredLocation.transform.position;
            }
        }
    }
}

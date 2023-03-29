using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public float CameraVertOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerCharacter.transform.position.x, PlayerCharacter.transform.position.y+CameraVertOffset, -10);
    }
}

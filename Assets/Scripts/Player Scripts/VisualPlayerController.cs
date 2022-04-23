using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPlayerController : MonoBehaviour
{
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}

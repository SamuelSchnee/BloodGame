using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollection : MonoBehaviour
{
    public float slam, dash, DJump, shield;
    public int slamUS, dashUS, DJumpUS, shieldUS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (dash >= 100)
        {
            dashUS = 1;
        }
        if (DJump >= 100)
        {
            DJumpUS = 1;
        }
        if (shield >= 100)
        {
            shieldUS = 1;
        }
    }

    public void increaseBlood(string type, float amount)
    {
        if (type == "slam")
        {
            Debug.Log(amount);
            slam += amount;
            if (slam >= 100)
            {
                slamUS = 1;
            }
        }
        else if (type == "dash")
        {
            dash += amount;
            if(dash >= 100)
            {
                dashUS = 1;
            }
        }
        else if (type == "djump")
        {

        }
    }
}

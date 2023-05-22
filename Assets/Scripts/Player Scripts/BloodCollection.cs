using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollection : MonoBehaviour
{
    public float heavy, dash, DJump, breaker, shoot;
    public int heavyUS, dashUS, DJumpUS, breakerUS, shootUS;

    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (heavy >= 100)
        {
            heavyUS = 1;
        }
        if (DJump >= 100)
        {
            DJumpUS = 1;
        }
        if (breaker >= 100)
        {
            breakerUS = 1;
        }
        if(shoot >= 100)
        {
            shootUS = 1;
        }
    }

    public void increaseBlood(string type, float amount)
    {
        if (type == "shoot")
        {
            Debug.Log(amount);
            shoot += amount;
            pauseMenu.TrackShoot(shoot);
            if (shoot >= 100)
            {
                shootUS = 1;
            }
        }
        else if (type == "breaker")
        {
            breaker += amount;
            pauseMenu.TrackBreak(breaker);
            if(breaker >= 100)
            {
                breakerUS = 1;
            }
        }
        else if (type == "djump")
        {
            DJump += amount;
            pauseMenu.TrackBloodDJump(DJump);
            if(DJump >= 100)
            {
                DJumpUS = 1;
            }
        }
        else if (type == "heavy")
        {
            heavy += amount;
            pauseMenu.TrackHeavy(heavy);
            if(heavy >= 100)
            {
                heavyUS = 1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BloodCollection : MonoBehaviour
{
    public float heavy, dash, DJump, breaker, shoot;
    public int heavyUS, dashUS, DJumpUS, breakerUS, shootUS;

    public bool heavyFK, DJumpFK, breakerFK, shootFK;
    private bool heavyAK, djumpAK, breakerAK, shootAK;

    public PauseMenu pauseMenu;

    public EnemyInfo info;


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
            if(shootFK == false)
            {
                shootFK = true;
                info.InfoGraphics("spitter");
            }
            Debug.Log(amount);
            shoot += amount;
            pauseMenu.TrackShoot(shoot);
            if (shoot >= 100)
            {
                shootUS = 1;
                if(shootAK == false)
                {
                    shootAK = true;
                    info.PowerGraphic("spitter");
                }
            }
        }
        else if (type == "breaker")
        {
            if(breakerFK == false)
            {
                breakerFK = true;
                info.InfoGraphics("crusher");
            }
            breaker += amount;
            pauseMenu.TrackBreak(breaker);
            if(breaker >= 100)
            {
                breakerUS = 1;
                if(breakerAK == false)
                {
                    breakerAK = true;
                    info.PowerGraphic("crusher");
                }
            }
        }
        else if (type == "djump")
        {
            if(DJumpFK == false)
            {
                DJumpFK = true;
                info.InfoGraphics("frog");
            }
            DJump += amount;
            pauseMenu.TrackBloodDJump(DJump);
            if(DJump >= 100)
            {
                DJumpUS = 1;
                if(djumpAK == false)
                {
                    djumpAK = true;
                    info.PowerGraphic("frog");
                }
            }
        }
        else if (type == "heavy")
        {
            if(heavyFK == false)
            {
                heavyFK = true;
                info.InfoGraphics("fly");
            }
            heavy += amount;
            pauseMenu.TrackHeavy(heavy);
            if(heavy >= 100)
            {
                heavyUS = 1;
                if(heavyAK == false)
                {
                    heavyAK = true;
                    info.PowerGraphic("fly");
                }
            }
        }
    }
}

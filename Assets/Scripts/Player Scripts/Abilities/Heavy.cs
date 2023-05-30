using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : Ability
{
    public bool heavyOn = false;
    public PlayerController plyrCntrl;
    public BuoyancyEffector2D waterEffector;
    public float maxCooldown = 1;
    public BloodCollection bloodCollect;

    private void Start()
    {
        plyrCntrl = GetComponent<PlayerController>();
        bloodCollect = GetComponent<BloodCollection>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && cooldown <= 0 && bloodCollect.heavyUS ==1)
        {
            Debug.Log("hitting R");
            if (heavyOn == false)
            {
                heavyOn = true;
                plyrCntrl.maxSpeed = 1;
            }

            else if (heavyOn == true)
            {
                heavyOn = false;
                plyrCntrl.maxSpeed = 5;
            }

            cooldown = maxCooldown;
        }

        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            waterEffector = other.gameObject.GetComponent<BuoyancyEffector2D>();
            if(heavyOn == true)
            {
                waterEffector.density = 0;
            }
            if(heavyOn == false)
            {
                waterEffector.density = 2;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            waterEffector = other.gameObject.GetComponent<BuoyancyEffector2D>();
            if(heavyOn == true)
            {
                waterEffector.density = 0;
            }
            else if(heavyOn == false)
            {
                waterEffector.density = 2;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       /* if(other.gameObject.tag == "Water")
        {
            waterEffector = null;
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : Ability
{
    public bool heavyOn = false;
    public PlayerController plyrCntrl;
    public BuoyancyEffector2D waterEffector;
    public float maxCooldown = 1;

    private void Start()
    {
        plyrCntrl = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && cooldown <= 0)
        {
            Debug.Log("hitting R");
            if (heavyOn == false)
            {
                heavyOn = true;
                plyrCntrl.maxSpeed = 1;
                if(waterEffector != null)
                {
                    waterEffector.density = 0;
                }
            }

            else if (heavyOn == true)
            {
                heavyOn = false;
                plyrCntrl.maxSpeed = 5;
                if(waterEffector != null)
                {
                    waterEffector.density = 2;
                }
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Water")
        {
            waterEffector = null;
        }
    }
}

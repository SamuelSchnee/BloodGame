using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdviceController : MonoBehaviour
{
    public float cooldown;
    public float maxCooldown;
    public float counter = 0;

    public GameObject KillText;
    public GameObject EverythingText;

    // Start is called before the first frame update
    void Start()
    {
        maxCooldown = 1;
        cooldown = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0)
        {
            if(counter == 0)
            {
                KillText.SetActive(true);
                cooldown = maxCooldown;
                counter = 1;
            }
            else if (counter == 1)
            {
                EverythingText.SetActive(true);
                maxCooldown = 2;
                cooldown = maxCooldown;
                counter = 2;
            }
            else if (counter == 2)
            {
                SceneManager.LoadScene("Full World");
            }
        }
        
    }
}

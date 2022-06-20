using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBlood : MonoBehaviour
{
    public string bloodType;
    public float bloodAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveBloodToPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        BloodCollection bloodCollection = playerObject.GetComponent<BloodCollection>();
        bloodCollection.increaseBlood(bloodType, bloodAmount);
    }
}

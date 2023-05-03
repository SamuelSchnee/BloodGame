using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    public UIController myUI;
    public GameObject UIController;

    private void Start()
    {
        UIController = GameObject.FindGameObjectWithTag("UIController");
        myUI = UIController.GetComponent<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            myUI.CoinCollected();
            Destroy(this.gameObject);
        }
    }
}

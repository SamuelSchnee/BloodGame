using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    public int coinsCollected = 0;
    public int maxCoins = 3;

    [SerializeField] private TextMeshProUGUI coinsText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coinsCollected ++;
            coinsText.text = "Coins Collected:" + coinsCollected + "/" + maxCoins;
            AllCoinsCollected();
        }
    }

    void AllCoinsCollected()
    {
        if(coinsCollected >= maxCoins)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

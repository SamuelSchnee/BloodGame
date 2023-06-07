using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public int coinsCollected = 0;
    public int maxCoins = 3;

    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText.text = "Coins Collected: 0/" + maxCoins;
    }
    public void CoinCollected()
    {
        coinsCollected++;
        coinsText.text = "Coins Collected:" + coinsCollected + "/" + maxCoins;
        if(coinsCollected >= maxCoins)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public GameObject spitterInfo, frogInfo, flyInfo, crusherInfo;

    public void InfoGraphics(string enemyType)
    {
        if(enemyType == "spitter")
        {
            spitterInfo.SetActive(true);
        }
        else if(enemyType == "frog")
        {
            frogInfo.SetActive(true);
        }
        else if(enemyType == "fly")
        {
            flyInfo.SetActive(true);
        }
        else if(enemyType == "crusher")
        {
            crusherInfo.SetActive(true);
        }
        Time.timeScale = 0;
    }
    public void CloseGraphic(string enemyType)
    {
        if (enemyType == "spitter")
        {
            spitterInfo.SetActive(false);
        }
        else if (enemyType == "frog")
        {
            frogInfo.SetActive(false);
        }
        else if (enemyType == "fly")
        {
            flyInfo.SetActive(false);
        }
        else if (enemyType == "crusher")
        {
            crusherInfo.SetActive(false);
        }
        Time.timeScale = 1;
    }
}

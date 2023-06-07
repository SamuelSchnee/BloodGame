using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void BeginButton()
    {
        SceneManager.LoadScene("Full World");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("IntroScene");
    }
}

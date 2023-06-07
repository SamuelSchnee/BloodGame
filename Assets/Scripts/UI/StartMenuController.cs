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
        SceneManager.LoadScene("AdviceScene");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

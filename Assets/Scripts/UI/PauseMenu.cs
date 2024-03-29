using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    public Slider djumpSlider, shootSlider, breakSlider, heavySlider;
    public TextMeshProUGUI djText, shootText, breakText, heavyText;

    void Start()
    {
        pauseMenu.SetActive(false);
        djumpSlider.value = 0;
        shootSlider.value = 0;
        breakSlider.value = 0;
        heavySlider.value = 0;
        djText.text = "Hard Shell Frogs: 0/100";
        shootText.text = "Spitters: 0/100";
        breakText.text = "Crushers: 0/100";
        heavyText.text = "Titan Flys: 0/100";

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TrackBloodDJump(float blood)
    {
        djumpSlider.value = blood;
        djText.text = "Hard Shell Frogs: " + blood + "/100";
    }
    public void TrackShoot(float blood)
    {
        shootSlider.value = blood;
        shootText.text = "Spitters: " + blood + "/100";
    }
    public void TrackBreak(float blood)
    {
        breakSlider.value = blood;
        breakText.text = "Crushers: " + blood + "/100"; 
    }
    public void TrackHeavy(float blood)
    {
        heavySlider.value = blood;
        heavyText.text = "Titan Flys: " + blood + "/100";
    }
}

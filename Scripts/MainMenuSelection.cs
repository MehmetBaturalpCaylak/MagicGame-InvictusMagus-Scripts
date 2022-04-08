using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelection : MonoBehaviour
{
    public AudioSource but;
    public void selectPlayGame()
    {
        but.Play();
        SceneManager.LoadScene("GameStartMenu");
    }

    public void selectTraining()
    {
        but.Play();
        SceneManager.LoadScene("TrainingScene");
    }

    public void selectOptions()
    {
        but.Play();
        SceneManager.LoadScene("OptionsMenu");
    }

    public void selectHowToPlay()
    {
        but.Play();
        SceneManager.LoadScene("HowToPlayMenu");
    }

    public void selectCredits()
    {
        but.Play();
        SceneManager.LoadScene("CreditsMenu");
    }

    public void selectQuit()
    {
        but.Play();
        Application.Quit();
    }
}

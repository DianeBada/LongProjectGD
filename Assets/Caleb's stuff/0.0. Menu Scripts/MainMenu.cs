using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource startAudio;
    public AudioSource quitAudio;
    public AudioSource creditAudio;
    public AudioSource mainMenuAudio;

    //BUTTONS
    public void StartButton()
    {
        //Audio
        startAudio.Play();

        //Change to Tutorial scene
        SceneManager.LoadScene("Level_Tutorial");
    }

    public void QuitButton()
    {
        //Audio
        quitAudio.Play();

        //Quit game
        Application.Quit();

        //Message
        Debug.Log("Player quit the game");
    }

    public void Credits()
    {
        //Audio
        creditAudio.Play();

        print("Credit Audio played");
    }

    public void TheMainMenu()
    {
        //Audio
        mainMenuAudio.Play();

        //Change to Tutorial scene
        SceneManager.LoadScene("3. Main Menu");
    }
}

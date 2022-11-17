using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource startAudio;
    public AudioSource quitAudio;

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
        startAudio.Play();
    }
}

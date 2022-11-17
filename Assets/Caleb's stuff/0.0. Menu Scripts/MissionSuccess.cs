using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionSuccess : MonoBehaviour
{
    public AudioSource buttonClick;

    public void MainMenu_Butt()
    {
        //Change Main Menu
        SceneManager.LoadScene("3. Main Menu");

        //Play audio
        buttonClick.Play();

        //Back to the main menu
        print("Main Menu scene is loaded");
    }
}

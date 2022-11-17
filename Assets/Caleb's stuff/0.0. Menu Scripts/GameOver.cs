using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //Add audio source to respective game objects
    public AudioSource GameOverSound;
    public AudioSource MenuClick_TryAgain; 
    public AudioSource MenuClick_MainMenu;

    void Start()
    {
        GameOverSound.Play(); //play game over sound at the start
    }


    //Press Try aagain
    public void TryAgain()
    {
        //Play Sound Effect
        MenuClick_TryAgain.Play();


        //Load Level



        Debug.Log("THE LEVEL IS LOADED!");
    }

    //Press Main Menu
    public void MainMenu()
    {
        //Play Sound Effect
        MenuClick_MainMenu.Play();


        //Load Main Menu



        Debug.Log("RETURN TO MAIN MENU!");
    }
}

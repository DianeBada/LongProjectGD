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

    //Maybe make it static
    public int LevelNumber; //The number of each level

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
        if(LevelNumber == 0) //Main Menu
        {
            //This is to make sure that the number resets if players go back to the Main Menu
            SceneManager.LoadScene("3. Main Menu");
        }
        else if (LevelNumber == 1) //Tutorial
        {

            //Change to LEVEL ONE scene
            SceneManager.LoadScene("Level_Tutorial");
        }
        else if (LevelNumber == 2) //Level ONE
        {
            
            //Change to Tutorial scene
            SceneManager.LoadScene("Level_One");
        }
        else if (LevelNumber == 3) //Level TWO
        {
            
            //Change to Level TWOl scene
            SceneManager.LoadScene("Level_Two");
        }
        else if (LevelNumber == 4) //Level THREE
        {
            
            //Change to Level THREE scene
            SceneManager.LoadScene("Level_Three");
        }
        else if (LevelNumber == 5) //Level FOUR
        {
            
            //Change to Level FOUR scene
            SceneManager.LoadScene("TheFourthLevel 1");
        }

        Debug.Log("THE LEVEL IS LOADED!");
    }

    //Press Main Menu
    public void MainMenu()
    {
        //Play Sound Effect
        MenuClick_MainMenu.Play();

        //Change to main menu scene
        SceneManager.LoadScene("3. Main Menu");

        Debug.Log("RETURN TO MAIN MENU!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //Gameobject
    public GameObject HeadingGameobject;
    public GameObject PromptGameobject;

    public bool headingAppears;

    //Audio source
    public AudioSource headingAudio;
    public AudioSource promptAudio;

    void Start()
    {
        HeadingGameobject.SetActive(false);
        PromptGameobject.SetActive(false);

        headingAppears = false;
    }


    void Update()
    {
        StartCoroutine(TextAppears());

        //Press SpaceBar to change scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");

            //play audio
            promptAudio.Play();

            //Change to main menu scene
            SceneManager.LoadScene("3. Main Menu");
        }

        if (headingAppears)
        {
            headingAudio.Play(); //play audio
        }
    }

    //Delay using Coroutines
    private IEnumerator TextAppears()
    {
        //Set active:
        //HEading after 5 seconds
        yield return new WaitForSeconds(5);
        HeadingGameobject.SetActive(true);
        headingAppears = true;

        //Propmt after 7 seconds
        yield return new WaitForSeconds(2);
        PromptGameobject.SetActive(true);
    }

}

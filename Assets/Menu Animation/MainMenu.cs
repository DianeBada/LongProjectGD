using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Gameobject
    public GameObject HeadingGameobject;
    public GameObject PromptGameobject;

    void Start()
    {
        HeadingGameobject.SetActive(false);
        PromptGameobject.SetActive(false);
    }


    void Update()
    {
        StartCoroutine(TextAppears());

        //Press SpaceBar to change scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");

            //Change to main menu scene
        }
    }

    private IEnumerator TextAppears()
    {
        //Set active:
        //HEading after 5 seconds
        yield return new WaitForSeconds(5);
        HeadingGameobject.SetActive(true);

        //Propmt after 7 seconds
        yield return new WaitForSeconds(7);
        PromptGameobject.SetActive(true);
    }
}

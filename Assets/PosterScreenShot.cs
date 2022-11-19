using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterScreenShot : MonoBehaviour
{
    //Saves a screenshot when a button is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot("Poster.png");
            Debug.Log("A screenshot was taken!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPreview : MonoBehaviour
{

    

    public GameObject mainCam;
    public GameObject previewCam;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerMovement.deathTimes < 1)
        {
            mainCam.SetActive(false);
            StartCoroutine(Preview());
        }
        else if (PlayerMovement.deathTimes>=1)
        {
            mainCam.SetActive(true);
            previewCam.SetActive(false);
        }
            

      
    }

    IEnumerator Preview()
    {
        yield return new WaitForSeconds(6);
        mainCam.SetActive(true);
        previewCam.SetActive(false);
    }
}

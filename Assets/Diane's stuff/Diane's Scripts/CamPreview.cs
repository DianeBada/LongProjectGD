using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPreview : MonoBehaviour
{
    public static bool isDonePreview = false;
    public static bool isStart = false;


    [SerializeField]
    public float panningTime = 6f;
    

    public GameObject mainCam;
    public GameObject previewCam;
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerMovement.deathTimes < 1)
        {
            mainCam.SetActive(false);
            StartCoroutine(Preview());
            isDonePreview = true;
            isStart = true;
        }
        else if (PlayerMovement.deathTimes>=1)
        {
            mainCam.SetActive(true);
            previewCam.SetActive(false);
        }
            

      
    }

    IEnumerator Preview()
    {
        yield return new WaitForSeconds(panningTime);
        mainCam.SetActive(true);
        previewCam.SetActive(false);
    }
}

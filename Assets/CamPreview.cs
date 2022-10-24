using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPreview : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject previewCam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Preview());
    }

    IEnumerator Preview()
    {
        yield return new WaitForSeconds(5);
        mainCam.SetActive(true);
        previewCam.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_OneMessage : MonoBehaviour
{
    public GameObject messagePanel;
   public static bool showMessage;
    // Start is called before the first frame update
    void Start()
    {
        messagePanel.SetActive(false);
        showMessage = true;
        StartCoroutine(ShowMessage());

    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator ShowMessage()
    {
        if (CamPreview.isDonePreview)
        {
            yield return new WaitForSeconds(11f);
            messagePanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            messagePanel.SetActive(false);
            CamPreview.isDonePreview = false;


        }


    }

    public void HideMessage()
    {
        if(CamPreview.isDonePreview == false )
        {
            messagePanel.SetActive(false);

        }

    }


}

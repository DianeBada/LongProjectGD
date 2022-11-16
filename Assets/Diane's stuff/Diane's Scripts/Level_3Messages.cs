using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3Messages : MonoBehaviour
{

    public GameObject shrinkMessage;
    public GameObject shootMessage;
    // Start is called before the first frame update
    void Start()
    {
        shrinkMessage.SetActive(false);
        shootMessage.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(displayMessage());
    }

    IEnumerator displayMessage()
    {
        if(PurchaseActions.displayShrinkMessage == true)
        {
            yield return new WaitForSeconds(2f);
            shrinkMessage.SetActive(true);
            yield return new WaitForSeconds(2f);
            shrinkMessage.SetActive(false);
            PurchaseActions.displayShrinkMessage = false;
        }

        if(PurchaseActions.displayShootMessage == true)
        {
            yield return new WaitForSeconds(2f);
            shootMessage.SetActive(true);
            yield return new WaitForSeconds(2f);
            shootMessage.SetActive(false);
            PurchaseActions.displayShootMessage = false;


        }
    }
}

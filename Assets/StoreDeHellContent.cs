// Cat// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/
// https://cattatonicat.tumblr.com/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreDeHellContent : MonoBehaviour
{ 

    private GameObject[] actions;
    private GameObject[] humans;
    private GameObject storeCanvas;
    private GameObject storeIcon;


    private void Awake()
    {
        storeCanvas = GameObject.Find("Store Canvas").transform.GetChild(0).gameObject;

        // storeCanvas = GameObject.FindGameObjectWithTag("storeCanvas");
        storeIcon = GameObject.FindGameObjectWithTag("storeIcon");



        storeIcon.SetActive(true);
       storeCanvas.SetActive(false);
    }

    private void Update()
    {
        //if(CattatonicatManager.StoreOnDisplay)
        //{
        //    ShowItems();
        //}
    }

   

   

    public void showActions() // be showing different mechanics
    {
        //foreach (GameObject actions in actions)
        //{
        //    actions.SetActive(true);
        //}
        storeIcon.SetActive(false);

        storeCanvas.SetActive(true);



    }


    public void HideStore()
    {

        storeCanvas.SetActive(false);
        storeIcon.SetActive(true);

    }






}

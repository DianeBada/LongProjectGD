


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StoreDeHellContent : MonoBehaviour
{
    public static bool isOpen = false;
    public static GameObject storeCanvas;
    private GameObject storeIcon;

    public GameObject jumpingStore;
    public GameObject climbingStore;
    public GameObject dashingStore;
    public GameObject shrinkingStore;
    public GameObject shootingStore;





    private void Awake()
    {
        storeCanvas = GameObject.Find("Store Canvas").transform.GetChild(0).gameObject;
        Debug.Log("found storeCnvas");

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

        FruitsManager();
    }

   

   

    public void showActions() // be showing different mechanics
    {
        //foreach (GameObject actions in actions)
        //{
        //    actions.SetActive(true);
        //}
        storeIcon.SetActive(false);

        storeCanvas.SetActive(true);
        isOpen = true;
        Debug.Log("StoreIcon is working");



    }


    public void HideStore()
    {

        storeCanvas.SetActive(false);
        isOpen = false;
        storeIcon.SetActive(true);

    }


    public void FruitsManager()
    {
        {
            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;
            Debug.Log(currentScene.name);

            if (storeCanvas.gameObject.activeInHierarchy == true)
            {
                if (sceneName == "Level_One")
                {
                    // Do something...
                    jumpingStore.SetActive(true);
                    climbingStore.SetActive(true);
                    dashingStore.SetActive(false);
                    shootingStore.SetActive(false);
                    shrinkingStore.SetActive(false);


                }


                else if(sceneName == "Level_Two")
                {
                   
                        // Do something...
                        jumpingStore.SetActive(true);
                        climbingStore.SetActive(true);
                        dashingStore.SetActive(true);
                        shootingStore.SetActive(false);
                        shrinkingStore.SetActive(false);


                    }

                else if (sceneName == "Level_Three")
                {

                    // Do something...
                    jumpingStore.SetActive(true);
                    climbingStore.SetActive(true);
                    dashingStore.SetActive(true);
                    shootingStore.SetActive(true);
                    shrinkingStore.SetActive(true);


                }

                else if (sceneName == "Level_Four")
                {

                    // Do something...
                    jumpingStore.SetActive(true);
                    climbingStore.SetActive(true);
                    dashingStore.SetActive(true);
                    shootingStore.SetActive(true);
                    shrinkingStore.SetActive(true);


                }

            }


            }
        }



    }

   





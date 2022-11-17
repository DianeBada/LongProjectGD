using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private string sceneName;
    public bool hasChanged;
    Scene currentScene;
    ActionsManager actionsManager;
    Reset resetScene;
    PurchaseActions purchScript;

    public bool changeLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        actionsManager = GetComponent<ActionsManager>();
        currentScene = SceneManager.GetActiveScene();
        resetScene = GetComponent<Reset>();
        purchScript = GetComponent<PurchaseActions>();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
        Debug.Log(currentScene.name);


    }

    // Update is called once per frame
    void Update()
    {
        CheckPreview();
        ResetAction();
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            if (sceneName == "Level_One")
            {
             
                SceneManager.LoadScene("Level_Two");

            }
            else if (sceneName == "Level_Two")
            {
                SceneManager.LoadScene("Level_Three");

            }
           else if (sceneName == "Level_Three")
            {
                SceneManager.LoadScene("Level_Four");

            }
        }
    }

    public void ResetAction()
    {
        if (sceneName == "Level_Two")
        {
           // changeLevel = true;

            //purchScript.GetComponent<PurchaseActions>().enabled = false;
            //    actionsManager.hasClimbing = false;
            //    actionsManager.hasJumping = false;
            //    actionsManager.hasShrinking = false;
            //    actionsManager.hasJumping = false;
            //    actionsManager.hasDashing = false;

            //    PurchaseActions.climbing = false;
            //    PurchaseActions.shrinking = false;
            //    PurchaseActions.jumping = false;
            //    PurchaseActions.dashing = false;


            //}

            //purchScript.GetComponent<PurchaseActions>().enabled = true;

        }
    }

    public void CheckPreview()
    {
        if(CamPreview.isDonePreview == true && currentScene.name == "Level_Two")
        {
        }
    }
}

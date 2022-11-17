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

    // Start is called before the first frame update
    void Start()
    {
        actionsManager = GetComponent<ActionsManager>();
        currentScene = SceneManager.GetActiveScene();
        resetScene = GetComponent<Reset>();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
        Debug.Log(currentScene.name);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            if (sceneName == "Level_One")
            {
                SceneManager.LoadScene("Level_Two");
                hasChanged = true;
               

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
        if ( sceneName == "Level_Two" && resetScene.newSceneLoad == true)
        {
            {
                actionsManager.hasClimbing = false;
                actionsManager.hasJumping = false;
                actionsManager.hasShrinking = false;
                actionsManager.hasJumping = false;
                actionsManager.hasDashing = false;

                PurchaseActions.climbing = false;
                PurchaseActions.shrinking = false;
                PurchaseActions.jumping = false;
                PurchaseActions.dashing = false;
            }

        }
    }
}

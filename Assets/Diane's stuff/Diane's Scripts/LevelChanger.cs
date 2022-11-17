using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    private string sceneName;
    public bool hasChanged;

    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();

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

    public void Reset()
    {
        if(CamPreview.isDonePreview)
        {
            if (hasChanged == true)
            {
                ActionsManager.hasClimbing = false;
                ActionsManager.hasJumping = false;
                ActionsManager.hasShrinking = false;
                ActionsManager.hasJumping = false;
                ActionsManager.hasDashing = false;

                PurchaseActions.climbing = false;
                PurchaseActions.shrinking = false;
                PurchaseActions.jumping = false;
                PurchaseActions.dashing = false;
            }

            hasChanged = false;


        }
    }
}

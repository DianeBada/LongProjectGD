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
    public GameObject GManager;
    //PlayerMovement playerMove;
    public GameObject Player;

    public bool changeLevel = false;
    // public GameObject ballPrefab;
    // public GameObject originalBall;

    // Start is called before the first frame update

   void Awake()
    {

    }
    void Start()
    {
        actionsManager = GetComponent<ActionsManager>();
        currentScene = SceneManager.GetActiveScene();
        resetScene = GetComponent<Reset>();
        GManager.GetComponent<PurchaseActions>();
        Player.GetComponent<PlayerMovement>();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
        Debug.Log(currentScene.name);

        SceneManager.sceneLoaded += onSceneLoaded;


    }

    // Update is called once per frame
    void Update()
    {
        CheckPreview();
        SceneManager.sceneLoaded += onSceneLoaded;
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
                SceneManager.LoadScene("TheFourthLevel 1");

            }

            else if (sceneName == "TheFourthLevel 1")
            {
                SceneManager.LoadScene("Game Over");

            }
        }
    }

    public void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level_Two")
        {
            
            GManager = GameObject.Find("Game Manager");
            Player = GameObject.Find("player");
            changeLevel = true;
            GManager.GetComponent<PurchaseActions>().hasBoughtClimb = false;

            //GManager.GetComponent<PurchaseActions>().hasBoughtClimb = false;
            //GManager.GetComponent<PurchaseActions>().hasBoughtShoot = false;
            //GManager.GetComponent<PurchaseActions>().hasBoughtShrink = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtJump = false;
            Player.GetComponent<PlayerMovement>().extraJumps = 0;

            GManager.GetComponent<PurchaseActions>().hasBoughtDash = false;


        }
        if (scene.name == "Level_Three")
        {

            GManager = GameObject.Find("Game Manager");
            Player = GameObject.Find("player");
            changeLevel = true;
            GManager.GetComponent<PurchaseActions>().hasBoughtClimb = false;

            //GManager.GetComponent<PurchaseActions>().hasBoughtClimb = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtShoot = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtShrink = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtJump = false;
            Player.GetComponent<PlayerMovement>().extraJumps = 0;

            GManager.GetComponent<PurchaseActions>().hasBoughtDash = false;


        }
        if (scene.name == "TheFourthLevel 1")
        {

            GManager = GameObject.Find("Game Manager");
            Player = GameObject.Find("player");
            changeLevel = true;
            GManager.GetComponent<PurchaseActions>().hasBoughtClimb = false;

            //GManager.GetComponent<PurchaseActions>().hasBoughtClimb = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtShoot = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtShrink = false;
            GManager.GetComponent<PurchaseActions>().hasBoughtJump = false;
            Player.GetComponent<PlayerMovement>().extraJumps = 0;

            GManager.GetComponent<PurchaseActions>().hasBoughtDash = false;


        }
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

    public void CheckPreview()
    {
        if(CamPreview.isDonePreview == true && currentScene.name == "Level_Two")
        {
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public bool newSceneLoad = false;

    ActionsManager actionsManager;
    CamPreview camprev;
    // Start is called before the first frame update

    void Awake()
    {
        

        
}
    void Start()
    {
        actionsManager = GetComponent<ActionsManager>();
        camprev = GetComponent<CamPreview>();
        newSceneLoad = true;

    }
    // Update is called once per frame
    void Update()
    {


        //{
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

        //camprev.isStart = false;



        //if (CamPreview.isStart == true)
        //{

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
    }
}

    

    

    


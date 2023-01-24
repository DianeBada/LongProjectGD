using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PurchaseActions : MonoBehaviour
{

    public int dashingCost = 6;
    public int walkingCost = 6;
    public int jumpingCost = 6;
    public int climbingCost = 6;
    public int shootingCost = 8;
    public int shrinkCost = 6;



    public bool dashing = false;
    public bool walking = false;
    public  bool jumping = false;
    public  bool shooting = false;
    public  bool climbing = false;
    public  bool shrinking = false;

    public bool hasBoughtWalk = false;
    public bool hasBoughtJump = false;
    public bool hasBoughtShoot = false;
    public bool hasBoughtClimb = false;
    public bool hasBoughtDash = false;
    public bool hasBoughtShrink = false;



    public bool canPurchase = true;
    public  TextMeshProUGUI currency;
    public  TextMeshProUGUI dashtext;
    public TextMeshProUGUI jumptext;
    public  TextMeshProUGUI climbtext;
    public  TextMeshProUGUI shoottext;
    public TextMeshProUGUI shrinktext;



    public static GameObject dashIcon;
    public static GameObject climbIcon;
    public static GameObject jumpIcon;
    public static GameObject shrinkIcon;
    public static GameObject shootIcon;



    public static bool displayShrinkMessage = false;
    public static bool displayShootMessage = false;

    public static int moneyCount = 15;


    // public TextMeshProUGUI shoottext;

    #region CAleb's stuff (animation):
    public Animator playerAnimator;
    #endregion

    ActionsManager actionsManager;
    GameObject playerMove;
    Reset resetScript;
    int money = moneyCount;
    void Awake()
    {



        actionsManager = GetComponent<ActionsManager>();





        // shoottext.text = "Shoot - " + shootingCost.ToString();


        jumpIcon = GameObject.FindGameObjectWithTag("jumpIcon");
        climbIcon = GameObject.FindGameObjectWithTag("climbIcon");
        dashIcon = GameObject.FindGameObjectWithTag("dashIcon");
        shrinkIcon = GameObject.FindGameObjectWithTag("shrinkIcon");
        shootIcon = GameObject.FindGameObjectWithTag("shootIcon");



        jumpIcon.SetActive(false);
        dashIcon.SetActive(false);
        climbIcon.SetActive(false);
        shrinkIcon.SetActive(false);
        shootIcon.SetActive(false);





        currency.text = "currency: " + moneyCount.ToString();
        dashtext.text = "Dash - " + dashingCost.ToString();
        jumptext.text = "2x Jump - " + jumpingCost.ToString();
        climbtext.text = "Climb - " + climbingCost.ToString();
        shrinktext.text = "Shrink - " + shrinkCost.ToString();
        shoottext.text = "Shoot - " + shootingCost.ToString();
        playerMove = GameObject.Find("player");

    }

   

    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log(  moneyCount);

        currency.text = "currency: " + moneyCount.ToString();


        if (hasBoughtWalk == true)
        {
            // show UI for has already been bought
        }

        if (hasBoughtJump == true)
        {
            jumpIcon.SetActive(true);
        }

        if (hasBoughtDash == true)
        {
            dashIcon.SetActive(true);
        }
        if (hasBoughtClimb == true)
        {
            climbIcon.SetActive(true);
        }
        if (hasBoughtShoot == true)
        {
            shootIcon.SetActive(true);
            // show UI for has already been bought
        }

        if(hasBoughtShrink == true)
        {
            shrinkIcon.SetActive(true);
        }

       
    }


    public void PurchasingWalk()
    {
        if (canPurchase && !hasBoughtWalk)
        {
            Debug.Log("is purchasing");


            if (moneyCount > walkingCost)
            {
                moneyCount -= walkingCost;
                hasBoughtWalk = true;
                actionsManager.hasWalking = true;
                walking = true;
                ActionsManager.actionCounter++;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");
                displayShrinkMessage = true;
            }
        }

    }

    public void PurchasingDash()
    {
        if (canPurchase && !hasBoughtDash)
        {
            Debug.Log("is purchasing");


            if (moneyCount > dashingCost)
            {


                moneyCount -= dashingCost;
                hasBoughtDash = true;
                actionsManager.hasDashing = true;
                dashing = true;
                ActionsManager.actionCounter++;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");

            }
        }

    }

    public void PurchasingJump()
    {
        if (canPurchase && !hasBoughtJump)
        {

            if (moneyCount > jumpingCost)
            {
                moneyCount -= jumpingCost;
                hasBoughtJump = true;
                actionsManager.hasJumping = true;
                jumping = true;
                
                playerMove. GetComponent<PlayerMovement>().extraJumps += 1;
                ActionsManager.actionCounter++;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");


            }
        }
    }

    public void PurchasingClimb()
    {
        if (canPurchase && !hasBoughtClimb)
        {
            if (moneyCount > climbingCost)
            {
                moneyCount -= climbingCost;
                hasBoughtClimb = true;
                actionsManager.hasClimbing = true;
                climbing = true;
                ActionsManager.actionCounter++;
                actionsManager.hasClimbing = true;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");
                hasBoughtClimb = true;


            }
        }
    }

    public void PurchasingShrink()
    {
        if (canPurchase && !hasBoughtShrink)
        {
            if (moneyCount > shrinkCost)
            {
                moneyCount -= shrinkCost;
                hasBoughtShrink = true;
                actionsManager.hasShrinking = true;
                shrinking = true;
                displayShrinkMessage = true;
                playerAnimator.SetTrigger("itemWasBought");


            }
        }
    }

    public void PurchasingShoot()
    {
        if (canPurchase && !hasBoughtShoot)
        {

            if (moneyCount > shootingCost)
            {
                moneyCount -= shootingCost;
                actionsManager.hasShooting = true;
                shooting = true;
                ActionsManager.actionCounter++;
                displayShootMessage = true;
                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");




            }

            

        }

    }

    //   public void ResetLevel()
    //{
    //    if(resetScript.unDoReset == false)
    //    {
    //        if (hasBoughtShoot == true)
    //        {
    //            hasBoughtShoot = false;
    //            actionsManager.hasShooting = false;
    //            shooting = false;
    //        }

    //        else if (hasBoughtShrink == true)
    //        {
    //            hasBoughtShrink = false;
    //            actionsManager.hasShrinking = false;
    //            shrinking = false;
    //        }

    //        else if (hasBoughtDash == true)
    //        {
    //            hasBoughtDash = false;
    //            actionsManager.hasClimbing = false;
    //            dashing = false;
    //        }

    //        else if (hasBoughtJump == true)
    //        {
    //            hasBoughtJump = false;
    //            actionsManager.hasJumping = false;
    //            PlayerMovement.extraJumps = 0;
    //            Debug.Log("no jumps for you");
    //            jumping = false;
    //        }

    //        else if (hasBoughtClimb == true)
    //        {
    //            hasBoughtClimb = false;
    //            actionsManager.hasClimbing = false;
    //            climbing = false;
    //        }


    //    }

       
         

    //    }

 

}








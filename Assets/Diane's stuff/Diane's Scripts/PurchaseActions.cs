using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PurchaseActions : MonoBehaviour
{

    private int dashingCost = 6;
    private int walkingCost = 6;
    private int jumpingCost = 6;
    private int climbingCost = 6;
    private int shootingCost = 8;
    private int shrinkCost = 6;



    public bool dashing = false;
    public bool walking = false;
    public static bool jumping = false;
    public bool shooting = false;
    public static bool climbing = false;
    public bool hasBoughtWalk = false;
    public bool hasBoughtJump = false;
    public bool hasBoughtShoot = false;
    public bool hasBoughtClimb = false;
    public bool hasBoughtDash = false;



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

   





    // public TextMeshProUGUI shoottext;

    #region CAleb's stuff (animation):
    public Animator playerAnimator;
    #endregion


    void Awake()
    {




        currency.text = "currency: " + ActionsManager.moneyCount.ToString();
        dashtext.text = "Dash - " + dashingCost.ToString();
        jumptext.text = "2x Jump - " + jumpingCost.ToString();
        climbtext.text = "Climb - " + climbingCost.ToString();
        shrinktext.text = "Shrink - " + shrinkCost.ToString();
        shoottext.text = "Climb - " + shootingCost.ToString();



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







    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        currency.text = "currency: " + ActionsManager.moneyCount.ToString();


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
            // show UI for has already been bought
        }

    }


    public void PurchasingWalk()
    {
        if (canPurchase && !hasBoughtWalk)
        {
            Debug.Log("is purchasing");


            if (ActionsManager.moneyCount > walkingCost)
            {
                ActionsManager.moneyCount -= walkingCost;
                ActionsManager.hasWalking = true;
                walking = true;
                ActionsManager.actionCounter++;
                hasBoughtWalk = true;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");
            }
        }

    }

    public void PurchasingDash()
    {
        if (canPurchase && !hasBoughtDash)
        {
            Debug.Log("is purchasing");


            if (ActionsManager.moneyCount > dashingCost)
            {
                ActionsManager.moneyCount -= dashingCost;
                ActionsManager.hasDashing = true;
                dashing = true;
                ActionsManager.actionCounter++;
                hasBoughtDash = true;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");

            }
        }

    }

    public void PurchasingJump()
    {
        if (canPurchase && !hasBoughtJump)
        {

            if (ActionsManager.moneyCount > jumpingCost)
            {
                ActionsManager.moneyCount -= jumpingCost;
                ActionsManager.hasJumping = true;
                jumping = true;
                PlayerMovement.extraJumps = 1;
                ActionsManager.actionCounter++;
                hasBoughtJump = true;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");


            }
        }
    }

    public void PurchasingClimb()
    {
        if (canPurchase && !hasBoughtClimb)
        {
            if (ActionsManager.moneyCount > climbingCost)
            {
                ActionsManager.moneyCount -= climbingCost;
                ActionsManager.hasClimbing = true;
                climbing = true;
                ActionsManager.actionCounter++;
                ActionsManager.hasClimbing = false;
                hasBoughtClimb = true;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");


            }
        }
    }

    public void PurchasingShoot()
    {
        if (canPurchase && !hasBoughtShoot)
        {

            if (ActionsManager.moneyCount > shootingCost)
            {
                ActionsManager.moneyCount -= shootingCost;
                ActionsManager.hasShooting = true;
                shooting = true;
                ActionsManager.actionCounter++;
                hasBoughtShoot = true;

                //Item Selection Animation
                playerAnimator.SetTrigger("itemWasBought");


            }


        }
    }


    
}


    


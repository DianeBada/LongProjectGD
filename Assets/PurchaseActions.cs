using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PurchaseActions : MonoBehaviour
{

    private int dashingCost = 6;
    private int walkingCost = 6;
    private int jumpingCost = 6;
    private int climbingCost = 6;
    private int shootingCost = 6;


    public bool dashing = false;
    public bool walking = false;
    public bool jumping = false;
    public bool shooting = false;
    public static bool climbing = false;
    public bool hasBoughtWalk = false; 
    public bool hasBoughtJump = false;
    public bool hasBoughtShoot = false;
    public bool hasBoughtClimb = false;
    public bool hasBoughtDash = false;



    public bool canPurchase = true;
    public TextMeshProUGUI currency;
    public TextMeshProUGUI walktext;
    public TextMeshProUGUI dashtext;
    public TextMeshProUGUI jumptext;
    public TextMeshProUGUI climbtext;
    public TextMeshProUGUI shoottext;


   void Awake()
    {




        currency.text = "Currency:  " + ActionsManager.moneyCount.ToString();
        walktext.text = "Run - " + walkingCost.ToString() + "curr";
        dashtext.text = "Dash - " + dashingCost.ToString();
        jumptext.text = "Jump - "+ jumpingCost.ToString();
        climbtext.text = "Climb - "+ climbingCost.ToString();
        shoottext.text = "Shoot - " + shootingCost.ToString();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ActionsManager.actionCounter >3)
            {
            canPurchase = false;
            // have UI saying sorry, cannot purchase more than 3 items
        }

       
        currency.text = "Currency:  " + ActionsManager.moneyCount.ToString();


        if(hasBoughtWalk == true)
        {
            // show UI for has already been bought
        }

        if (hasBoughtJump == true)
        {
            // show UI for has already been bought
        }

        if (hasBoughtDash == true)
        {
            // show UI for has already been bought
        }
        if (hasBoughtClimb == true)
        {
            // show UI for has already been bought
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
                ActionsManager.actionCounter++;
                hasBoughtJump = true;


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


            }


        }
    }


          

          

        }


    


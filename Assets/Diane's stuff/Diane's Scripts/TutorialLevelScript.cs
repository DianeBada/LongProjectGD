using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialLevelScript : MonoBehaviour
{
    public GameObject MovementPanel;
    public GameObject jumpPanel;
    public GameObject BananaClimbPanel;
    public GameObject CherryDJumpPanel;
    public GameObject ApricotDashPanel;
    public GameObject SpikesPanel;
    public GameObject coinsPanel;
    public GameObject mapPanel;


    public bool spikesTrigger = false;
    public bool exitTrigger = false;
    public bool hitJumpTrigger = false;
    public bool collBanana = false;
    public bool colCherry = false;
    public bool colApricot = false;
    public bool enterTrigger = false;
    public bool hitSpikes = false;
    public bool hasCoins = false;
    public bool hasMaptut = false;
    public GameObject player;
    public GameObject startPos;

    ActionsManager actionsManager;
    PurchaseActions purch;
    PlayerMovement playerMove;

    // Start is called before the first frame update
    void Start()
    {
        coinsPanel.SetActive(false);
        MovementPanel.gameObject.SetActive(false);
        BananaClimbPanel.SetActive(false);
        jumpPanel.SetActive(false);
        CherryDJumpPanel.SetActive(false);
        BananaClimbPanel.SetActive(false);
        ApricotDashPanel.SetActive(false);
        SpikesPanel.SetActive(false);
        mapPanel.SetActive(false);

        actionsManager = FindObjectOfType<ActionsManager>();
        purch =FindObjectOfType<PurchaseActions>();
        playerMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowMessage());


        if (hitSpikes == true)
        {
            SceneManager.LoadScene(("Level_Tutorial"));

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bannana-climb"))
        {
            collBanana = true;

            purch.hasBoughtClimb = true;
            purch.climbing = true;
        }

        if (collision.gameObject.CompareTag("cherry-doubleJump"))
        {
            colCherry = true;
            purch.hasBoughtJump = true;
            purch.jumping = true;
            playerMove.extraJumps = 1;
        }
        if (collision.gameObject.CompareTag("apricot-dash"))
        {
            colApricot = true;
            purch.hasBoughtDash = true;
        }

         if (collision.gameObject.tag == "spikes")
        {

            hitSpikes = true;
        }
        if (collision.gameObject.CompareTag("coins"))
        {
            hasCoins = true;
        }

        if (collision.gameObject.CompareTag("map-tut"))
        {
            hasMaptut = true;
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("jumpTrigger"))
        {
            hitJumpTrigger = true;

        }

        if (other.gameObject.CompareTag("exitTrigger"))
        {
            exitTrigger = true;
        }
        if (other.gameObject.CompareTag("spikesTrigger"))
        {
            spikesTrigger = true;
        }

        if (other.gameObject.CompareTag("enterTrigger"))
        {
            enterTrigger = true;
        }

        if(other.gameObject.CompareTag("portal-ring"))
        {
            SceneManager.LoadScene("Level_One");
        }
      
    }






    IEnumerator ShowMessage()
    {

        if (CamPreview.isDonePreview == true)
        {

            yield return new WaitForSeconds(6);
            if (enterTrigger == true)
            {
                MovementPanel.gameObject.SetActive(true);
                yield return new WaitForSeconds(2f);
                MovementPanel.gameObject.SetActive(false);

                enterTrigger = false;




            }
        }


        if (hitJumpTrigger == true)
        {
            jumpPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(3f);
            jumpPanel.gameObject.SetActive(false);
            hitJumpTrigger = false;



        }
        if (collBanana == true)
        {
            BananaClimbPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);
            BananaClimbPanel.gameObject.SetActive(false);
            collBanana = false;



        }

        if (colCherry == true)
        {
            CherryDJumpPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);
            CherryDJumpPanel.gameObject.SetActive(false);
            colCherry = false;


        }

        if (colApricot == true)
        {
            ApricotDashPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);
            ApricotDashPanel.gameObject.SetActive(false);
            colApricot = false;


        }



        if (spikesTrigger == true)
        {
            SpikesPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);
            SpikesPanel.gameObject.SetActive(false);
            spikesTrigger = false;
        }

        if (hasCoins == true)
        {
            coinsPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);
            coinsPanel.gameObject.SetActive(false);
            hasCoins = false;
        }
        if(hasMaptut == true)
        {
            mapPanel.gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            mapPanel.gameObject.SetActive(false);
            hasMaptut = false;
            //yield return new WaitForSeconds(1f);
            //SceneManager.LoadScene("Level_One");

        }

    }

}
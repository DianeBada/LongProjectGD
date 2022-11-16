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
    public bool spikesTrigger = false;
    public bool exitTrigger = false;
    public bool hitJumpTrigger = false;
    public bool collBanana = false;
    public bool colCherry = false;
    public bool colApricot = false;
    public bool enterTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        MovementPanel.gameObject.SetActive(false);
        BananaClimbPanel.SetActive(true);
        jumpPanel.SetActive(false);
        CherryDJumpPanel.SetActive(false);
        BananaClimbPanel.SetActive(false);
        ApricotDashPanel.SetActive(false);
        SpikesPanel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowMessage());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bannana-climb"))
        {
            collBanana = true;
            PurchaseActions.climbing = true;
        }

        if (collision.gameObject.CompareTag("cherry-doubleJump"))
        {
            colCherry = true;
            ActionsManager.hasJumping = true;
          PurchaseActions.jumping = true;
            PlayerMovement.extraJumps = 1;
        }
        if (collision.gameObject.CompareTag("apricot-dash"))
        {
            colApricot = true;
            ActionsManager.hasDashing = true;
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
    }


    
       
    

    IEnumerator ShowMessage()
    {
        
        if(CamPreview.isDonePreview == true)
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

            yield return new WaitForSeconds(3f);
            BananaClimbPanel.gameObject.SetActive(false);
            collBanana = false;



        }

        if (colCherry == true)
        {
            CherryDJumpPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(3f);
            CherryDJumpPanel.gameObject.SetActive(false);
            colCherry = false;


        }

        if (colApricot == true)
        {
            ApricotDashPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(3f);
            ApricotDashPanel.gameObject.SetActive(false);
            colApricot = false;


        }


       
        if (spikesTrigger == true)
        {
            SpikesPanel.gameObject.SetActive(true);

            yield return new WaitForSeconds(3f);
            SpikesPanel.gameObject.SetActive(false);
            spikesTrigger = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TutorialLevelScript : MonoBehaviour
{
    public GameObject MovementText;
    public GameObject jumpTrigger;
    public GameObject jumpText;
    public GameObject BannaClimbText;
    public GameObject CherryDJumpText;
    public GameObject ApricotDashText;
    public GameObject Panel;


    bool hitJumpTrigger = false;
    bool collBanana = false;
    bool colCherry = false;
    bool colApricot = false;
   

    // Start is called before the first frame update
    void Start()
    {
        Panel.gameObject.SetActive(true);
        MovementText.SetActive(true);
        jumpText.SetActive(false);
        jumpTrigger.SetActive(false);
        BannaClimbText.SetActive(false);
        CherryDJumpText.SetActive(false);
        ApricotDashText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShowMessage());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("jumpTrigger"))
        {
            hitJumpTrigger = true;
            
        }
        if (collision.gameObject.CompareTag("bannanaClimb"))
        {
            collBanana = true;
            PurchaseActions.climbing = true;
        }

        if (collision.gameObject.CompareTag("cherry-doubleJump"))
        {
            colCherry = true;
            ActionsManager.HasJumping = true;
           
        }
        if (collision.gameObject.CompareTag("apricot-dash"))
        {
            colApricot = true;
            ActionsManager.hasDashing = true;
        }
    }

    IEnumerator ShowMessage()
    {
        //yield return new WaitForSeconds(1f);
        //Panel.gameObject.SetActive(false);

        //MovementText.SetActive(false);

        if (hitJumpTrigger == true)
        {
            Panel.gameObject.SetActive(true);

            jumpText.SetActive(true);
            yield return new WaitForSeconds(1f);
            Panel.gameObject.SetActive(false);

            jumpText.SetActive(false);


        }
        if (collBanana == true)
        {
            Panel.gameObject.SetActive(true);

            BannaClimbText.SetActive(true);
            yield return new WaitForSeconds(1f);
            Panel.gameObject.SetActive(false);

            BannaClimbText.SetActive(false);


        }

        if (colCherry == true)
        {
            Panel.gameObject.SetActive(true);

            CherryDJumpText.SetActive(true);
            yield return new WaitForSeconds(1f);
            Panel.gameObject.SetActive(false);

            CherryDJumpText.SetActive(false);


        }

        if (ApricotDashText == true)
        {
            Panel.gameObject.SetActive(true);

            ApricotDashText.SetActive(true);
            yield return new WaitForSeconds(1f);
            Panel.gameObject.SetActive(false);

            ApricotDashText.SetActive(false);


        }




    }
}

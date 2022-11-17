using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;
    private AudioSource myAudio;
    ActionsManager actionsManager;
    PurchaseActions purch;

   void Start()
    {
        myAudio = GetComponent < AudioSource >() ;
        actionsManager = GetComponent<ActionsManager>();
        purch = GetComponent<PurchaseActions>();
    }
    void Update()
    {
        //Continously rotates
        this.transform.Rotate(0, 2, 0, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //  myAudio.PlayOneShot(coinSound);

            PurchaseActions.moneyCount += 2;

            this.gameObject.SetActive(false);
        }
    }


}

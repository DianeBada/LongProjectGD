using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;
    private AudioSource myAudio;

   void Start()
    {
        myAudio = GetComponent < AudioSource >() ;
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
            myAudio.PlayOneShot(coinSound);

            ActionsManager.moneyCount += 1;

            this.gameObject.SetActive(false);
        }
    }


}

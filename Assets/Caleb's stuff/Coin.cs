using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Update()
    {
        //Continously rotates
        this.transform.Rotate(0, 2, 0, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActionsManager.moneyCount += 3;

            this.gameObject.SetActive(false);
        }
    }
}

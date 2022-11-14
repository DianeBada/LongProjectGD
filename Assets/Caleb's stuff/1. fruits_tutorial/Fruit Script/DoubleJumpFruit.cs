using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpFruit : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(true);
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision)
    {
        //If it collides with the PLAYER
        if (collision.gameObject.tag == "Player")
        {

            //Activate Double Jump mechanic


            //deactive gameobject after collision
            this.gameObject.SetActive(false);
        }
    }
}

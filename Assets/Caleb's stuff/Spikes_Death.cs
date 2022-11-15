using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes_Death : MonoBehaviour
{
    public Animator playerAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement.deathTimes = +1;
            PlayerHealth.playerHealth -= 100;
            PlayerHealth.playerLives -= 1 ;

            //playerAnimator.SetTrigger("player Is Dead"); //Trigger prevents other animations from playing

            if (PlayerHealth.playerLives > 0)
            {
                PlayerHealth.isTempDead = true;
            }
            else
            {
                //Game Over : Game Over Scene
            }
        }
        //}


    }
}

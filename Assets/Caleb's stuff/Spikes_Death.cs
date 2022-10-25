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
            playerAnimator.SetTrigger("player Is Dead"); //Trigger prevents other animations from playing

            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("scene"); //reload scene
        if(PurchaseActions.jumpIcon.activeInHierarchy)
        {
            PurchaseActions.jumpIcon.SetActive(true);
        }
        else
            PurchaseActions.jumpIcon.SetActive(false);

    }
}

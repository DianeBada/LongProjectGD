using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    //public PickUp objectScript;
    public float playerHealth = 100f;


    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = slider.maxValue;
        SetMaxHealthValue();
    }

    public void DeductHealth(float deductHealth)
    {
        playerHealth -= deductHealth;
        SetHealth(playerHealth);
        if (playerHealth <= 0)
        {
            playerDead();
        }
    }

    void playerDead()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemies")
        {

            // Debug.Log(PickUp.throwForceValue);
            DeductHealth(15);
            Debug.Log(playerHealth);

        }

        else if (collision.gameObject.tag == "spikes")
        {
            DeductHealth(100);

        }
    }

    public void SetMaxHealthValue()
    {
        slider.maxValue = playerHealth;
        slider.value = playerHealth;
    }

    public void SetHealth(float health)
    {
        slider.value = playerHealth;
    }

}




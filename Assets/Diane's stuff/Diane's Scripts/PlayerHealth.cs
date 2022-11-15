using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    //public PickUp objectScript;
    public static float playerHealth = 100f;
    public static int playerLives = 2;
    public GameObject startPos;
    public GameObject player;
   public static bool isTempDead;
    public static bool isDead;
    public TextMeshProUGUI livesText;


    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = slider.maxValue;
        SetMaxHealthValue();
    }

    void Update()
    {

        SetHealth(playerHealth);
        livesText.text = "X" + playerLives.ToString();

    }
    public void DeductHealth(float deductHealth)
    {
        playerHealth -= deductHealth;
        SetHealth(playerHealth);
        if (playerHealth <= 0 && playerLives>0)
        {
           
            // implement text that shows amount of lives and changes it accordingly.
            playerLives = -1;
            isTempDead = true;
            playerDead();
            // make a function that takes them back to the beginning.
        }
        else if(playerHealth <=0 && playerLives <=0)
        {
            isDead = true;
            playerDead();

            // Game Over Scene
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

            DeductHealth(15);
            Debug.Log(playerHealth);

        }

        else if (collision.gameObject.tag == "spikes")
        {
            DeductHealth(100);

        }

        if (collision.gameObject.tag == "hearts") 
        {
            playerLives = +1;
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

    public void levelRestart()
    {
        if(isTempDead == true)
        {
            player.transform.position = startPos.transform.position;
        }
    }
}




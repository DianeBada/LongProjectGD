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
    public static int playerLives = 4;
    public GameObject startPos;
    public GameObject player;
   public static bool isTempDead;
    public static bool isDead;
    public TextMeshProUGUI livesText;
    public GameObject camStart;
    public Camera mainCam;
    public Animator playerAnimator;



    // Start is called before the first frame update
    public void Start()
    {
        livesText.text = "x" + playerLives.ToString();

        playerHealth = slider.maxValue;
        SetMaxHealthValue();
    }

    void Update()
    {

        SetHealth(playerHealth);

        if (playerHealth <= 0 && playerLives > 0)
        {

            // implement text that shows amount of lives and changes it accordingly.
            livesText.text = "x" + playerLives.ToString();
            isTempDead = true;
            StartCoroutine(LevelRestart());


            // make a function that takes them back to the beginning.
        }
        else if (playerHealth <= 0 && playerLives <= 0)
        {
            isDead = true;
            StartCoroutine(LevelRestart());

            //playerDead();

            // Game Over Scene
        }


    }
    public void DeductHealth(float deductHealth)
    {
        playerHealth -= deductHealth;
        SetHealth(playerHealth);
      
    }

    void playerDead()
    {
        Destroy(gameObject, 1f);
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
            playerLives--;



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

    //public void levelRestart()
    //{
    //    if(isTempDead == true)
    //    {
    //        WaitForSeconds(2f);
    //        player.transform.position = startPos.transform.position;
    //        mainCam.transform.position = camStart.transform.position;

    //    }

        IEnumerator LevelRestart()
        {
        if (isTempDead == true)
        {
            yield return new WaitForSeconds(1f);
           player.transform.position = startPos.transform.position;
            //mainCam.transform.position = camStart.transform.position;
            yield return new WaitForSeconds(.5f);
            playerHealth = 50;

        }
}
}




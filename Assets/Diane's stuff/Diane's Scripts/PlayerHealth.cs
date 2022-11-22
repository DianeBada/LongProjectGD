using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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
    public GameObject camStart;
    public Camera mainCam;
    public Animator playerAnimator;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    public int flickerAmount = 3;
    public float flickerDuration = 0.5f;
    public bool canTakeDamage = false;

    // Start is called before the first frame update
    public void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();

        livesText.text = "x" + playerLives.ToString();

        playerHealth = slider.maxValue;
        SetMaxHealthValue();
    }



    void Update()
    {
        TakingDamage();
        
        if (StoreDeHellContent.isOpen == true)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);

        }
        SetHealth(playerHealth);

        if (playerHealth <= 0 && playerLives > 0)
        {

            // implement text that shows amount of lives and changes it accordingly.
            livesText.text = "x" + playerLives.ToString();
            Debug.Log(playerLives);
            isTempDead = true;
            StartCoroutine(LevelRestart());


            // make a function that takes them back to the beginning.
        }
        else if (playerHealth <= 0 && playerLives <= 0)
        {
            livesText.text = "0";
            isDead = true;
            Time.timeScale = 0;
            Debug.Log("Game Over");
            //playerDead();

            SceneManager.LoadScene("Game Over");
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
        if (collision.gameObject.tag == "Enemy")
        {
           // StartCoroutine(Invunerability());
            DeductHealth(15);
            Debug.Log(playerHealth);

        }

         if (collision.gameObject.tag == "spikes")
        {
            //StartCoroutine(Invunerability());
            DeductHealth(100);
            playerLives -= 1;

        }

        if (collision.gameObject.tag == "hearts")
        {
            playerLives = +1;
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy projectiles")
        {
            Debug.Log("damage ffect for player is playing");
            canTakeDamage = true;
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
            yield return new WaitForSeconds(.1f);
            player.transform.position = startPos.transform.position;
            //mainCam.transform.position = camStart.transform.position;
            yield return new WaitForSeconds(.5f);
            playerHealth = 100;

        }

       


    }

    void TakingDamage()
    {
        if (canTakeDamage == true)
        {
            Debug.Log("Courotine starts for damage effect");
            StartCoroutine(DamageFlicker());
        }
    }

    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmount; i++)
        {
            spriteRend.color = new Color(0.85f, 0.157f, 0.157f, 0.5f);
            yield return new WaitForSeconds(flickerDuration);
        }
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(flickerDuration);
        canTakeDamage = false;

    }

    //IEnumerator Invunerability()
    //{
    //    invulnerable = true;
    //    Physics2D.IgnoreLayerCollision(8, 9, true);
    //    for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        spriteRend.color = new Color(1, 0, 0, 0.5f);
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //        spriteRend.color = Color.white;
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //    }
    //    Physics2D.IgnoreLayerCollision(10, 11, false);
    //    invulnerable = false;
    //}
}




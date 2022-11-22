using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public bool canTakeDamage = false;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

   public int flickerAmount = 3;
   public float flickerDuration = 0.5f;
    private void Awake()
    {
        currentHealth = startingHealth;
       // anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
     void Start()
    {
        //canTakeDamage = true;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {

            canTakeDamage = true;
            //anim.SetTrigger("hurt");
            // StartCoroutine(Invunerability());
            //SoundManager.instance.PlaySound(hurtSound);
        }
        else
            if (currentHealth== 0)
            {
            canTakeDamage = false;
            gameObject.SetActive(false);
            }
        }

     void Update()
    {
        TakingDmage();
            }

    void TakingDmage()
    {
        if(canTakeDamage == true)
        {
            Debug.Log("Courotine starts for damage effect");
            StartCoroutine(DamageFlicker());
        }
    }
    

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    //private IEnumerator Invunerability()
    //{
    //    invulnerable = true;
    //    Physics2D.IgnoreLayerCollision(8, 9, true);
    //    for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        spriteRend.color = new Color(0, 0, 0, 0.5f);
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //        spriteRend.color = Color.white;
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //    }
    //    Physics2D.IgnoreLayerCollision(8, 9, false);
    //    invulnerable = false;
    //}
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    //private IEnumerator Blink()
    //{
    //    SpriteRenderer playerSprite = gameObject.GetComponent<SpriteRenderer>();

    //    Color defaultColor = playerSprite.color;

    //    playerSprite.color = new Color(1, 1, 1, 1);

    //    yield return new WaitForSeconds(0.1f);

    //    playerSprite.color = defaultColor;
    //}

    IEnumerator DamageFlicker()
    {

        for(int i =0; i<flickerAmount; i++)
        {
            spriteRend.color = new Color(0.85f, 0.157f, 0.157f, 0.5f);
            yield return new WaitForSeconds(flickerDuration);
        }
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(flickerDuration);
        canTakeDamage = false;

    }

    //Respawn
    //public void Respawn()
    //{
    //    AddHealth(startingHealth);
    //    anim.ResetTrigger("die");
    //    anim.Play("Idle");
    //   // StartCoroutine(Invunerability());

    //    //Activate all attached component classes
    //    foreach (Behaviour component in components)
    //        component.enabled = true;
    //}
}
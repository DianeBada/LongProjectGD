using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    public float numberofShots;

    public bool ableToShoot;

    ActionsManager actionsManager;
    PurchaseActions purchase;
   public void Awake()

       
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        actionsManager = GetComponent<ActionsManager>();
        purchase = FindObjectOfType<PurchaseActions>();
        ableToShoot = Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackCooldown && playerMovement.canAttack() && purchase.hasBoughtShoot;
    }

     void Update()
    {


        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackCooldown && playerMovement.canAttack() && purchase.hasBoughtShoot)

        {
            Attack();

        }
        Debug.Log("is shooting");
        cooldownTimer += Time.deltaTime;
        Debug.Log(numberofShots);

      

      

       


        if (numberofShots >=10)
        {
            firePoint.gameObject.SetActive(false);

        }




    }

    public void Attack()
    {
       // SoundManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("isShooting");
        numberofShots += 1;

        cooldownTimer = 0;

        if(firePoint.gameObject.activeInHierarchy)
        {
            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }

        else
        {
            Debug.Log("out of ammo");
        }

        //numberofShots
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy )
                return i;

        }

        return 0;

    }

   

}
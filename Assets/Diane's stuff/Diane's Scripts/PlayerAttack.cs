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

    ActionsManager actionsManager;
    private void Awake()
    {
        //anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        actionsManager = GetComponent<ActionsManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && cooldownTimer > attackCooldown && playerMovement.canAttack() && actionsManager.hasShooting == true && PurchaseActions.shooting == true)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
       // SoundManager.instance.PlaySound(fireballSound);
       // anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage = 25;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerHealth>()?.DeductHealth(damage);
    }
}
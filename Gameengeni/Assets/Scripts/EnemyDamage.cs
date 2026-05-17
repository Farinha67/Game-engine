using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 1f;

    private float nextAttackTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }

                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}
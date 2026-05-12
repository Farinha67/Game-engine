using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;

    // Tempo entre ataques
    public float attackCooldown = 5f;

    private float nextAttackTime;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica se já pode atacar novamente
            if (Time.time >= nextAttackTime)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);

                    // Próximo ataque em 5 segundos
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }
}
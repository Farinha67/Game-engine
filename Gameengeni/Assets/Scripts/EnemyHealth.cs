using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 150;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Vida do inimigo: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Inimigo morreu");

        Destroy(gameObject);
    }
}
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int maxHealth = 100;

    // Item que esse inimigo vai dropar
    public GameObject dropItemPrefab;

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
        // Dropa item
        if (dropItemPrefab != null)
        {
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
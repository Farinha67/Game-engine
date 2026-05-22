using UnityEngine;

public class HalfLifeItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                // tira metade da vida atual
                int halfLife = player.currentHealth / 2;

                player.TakeDamage(halfLife);
            }

            Destroy(gameObject);
        }
    }
}
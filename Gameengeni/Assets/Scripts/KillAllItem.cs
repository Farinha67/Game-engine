using UnityEngine;

public class KillAllItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Procura TODOS os inimigos com HealthEnemy
            HealthEnemy[] enemies = FindObjectsByType<HealthEnemy>(FindObjectsSortMode.None);

            foreach (HealthEnemy enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }

            // Destrói o item
            Destroy(gameObject);
        }
    }
}
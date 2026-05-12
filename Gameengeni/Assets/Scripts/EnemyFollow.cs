using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    void Update()
    {
        // Verifica se o player existe
        if (player == null)
        {
            return;
        }

        // Faz o enemy seguir o player
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}
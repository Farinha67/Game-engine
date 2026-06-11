using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public int damage = 25;
    public float lifeTime = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Faz a bala andar para frente
        rb.linearVelocity = transform.forward * speed;

        // Destrói após alguns segundos
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ignora o Player
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        EnemyHealth enemy = collision.gameObject.GetComponentInParent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
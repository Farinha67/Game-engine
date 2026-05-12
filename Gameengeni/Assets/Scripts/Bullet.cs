using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
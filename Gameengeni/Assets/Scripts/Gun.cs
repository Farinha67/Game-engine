using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Cria a bala
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        // Pega rigidbody
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Faz a bala seguir a direção da câmera
        rb.linearVelocity = Camera.main.transform.forward * bulletSpeed;

        // Rotaciona visualmente a bala
        bullet.transform.forward = Camera.main.transform.forward;
    }
}
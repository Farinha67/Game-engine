using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Configurações de Tiro")]
    public GameObject bulletPrefab; // Arraste o Prefab da bala aqui
    public Transform firePoint;     // Arraste o objeto FirePoint aqui

    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // O "if" abaixo checa se você esqueceu de arrastar os objetos no Unity
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            // Isso vai aparecer no console se faltar algo, sem travar o jogo
            Debug.LogError("ERRO: Arraste o Prefab da bala e o FirePoint para o script no Inspector!");
        }
    }
}
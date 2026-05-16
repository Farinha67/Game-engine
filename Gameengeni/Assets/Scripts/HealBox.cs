using UnityEngine;

public class HealBox : MonoBehaviour
{
    public int cura = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();

            if (vida != null)
            {
                vida.Heal(cura);

                Destroy(gameObject);
            }
        }
    }
}
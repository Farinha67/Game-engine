using UnityEngine;
using TMPro;

public class FoodPickup : MonoBehaviour
{
    private bool playerPerto = false;
    private bool pegou = false;

    public TMP_Text itemText;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E) && !pegou)
        {
            pegou = true;

            if (itemText != null)
            {
                itemText.text = "Alimento";
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerPerto = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerPerto = false;
    }
}   
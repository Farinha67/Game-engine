using UnityEngine;
using TMPro;

public class FuelPickup : MonoBehaviour
{
    private bool playerPerto = false;
    public TMP_Text itemText;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            itemText.text = "Combustivel";
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
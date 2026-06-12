using UnityEngine;

public class FriendNPC : MonoBehaviour
{
    private bool playerPerto = false;

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Amigo: Preciso de remedios!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerPerto)
        {
            playerPerto = true;
            Debug.Log("Pressione E para conversar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;
            Debug.Log("Saiu da area");
        }
    }
}
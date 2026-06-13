using UnityEngine;
using TMPro;

public class FriendNPC : MonoBehaviour
{
    private bool playerPerto = false;
    private bool medicineEntregue = false;
    private bool foodEntregue = false;

    public TMP_Text dialogueText;
    public TMP_Text itemText;

    private FriendFollow followScript;
    private SphereCollider sphereCollider;

    void Start()
    {
        followScript = GetComponent<FriendFollow>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (playerPerto && Input.GetKeyDown(KeyCode.E))
        {
            // Missão do remédio
            if (!medicineEntregue)
            {
                if (itemText.text == "Remedio")
                {
                    medicineEntregue = true;
                    itemText.text = "";
                    dialogueText.text = "Obrigado... Ja me sinto melhor. Agora preciso de alimento.";
                }
                else
                {
                    dialogueText.text = "Preciso de remedios!";
                }
            }

            // Missão da comida
            else if (!foodEntregue)
            {
                if (itemText.text == "Alimento")
                {
                    foodEntregue = true;
                    itemText.text = "";
                    dialogueText.text = "Obrigado! Agora consigo andar.";

                    if (followScript != null)
                        followScript.podeSeguir = true;

                    // Desliga trigger de conversa
                    if (sphereCollider != null)
                        sphereCollider.enabled = false;
                }
                else
                {
                    dialogueText.text = "Preciso de alimento!";
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;

            if (!foodEntregue)
            {
                dialogueText.text = "Pressione E para conversar";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;

            if (!foodEntregue)
            {
                dialogueText.text = "";
            }
        }
    }
}
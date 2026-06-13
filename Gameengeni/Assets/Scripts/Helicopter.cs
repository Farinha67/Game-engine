using UnityEngine;
using TMPro;

public class Helicopter : MonoBehaviour
{
    private bool playerPerto = false;
    private bool verificou = false;
    private bool enchendo = false;
    private float tempoEnchendo = 0f;

    public TMP_Text dialogueText;
    public TMP_Text itemText;
    public FriendFollow friendFollow;

    void Update()
    {
        if (!playerPerto) return;

        // Primeira interação
        if (!verificou && Input.GetKeyDown(KeyCode.E))
        {
            verificou = true;
            dialogueText.text = "SEM COMBUSTIVEL!";

            friendFollow.PararSeguir();
            Invoke(nameof(FalarNPC), 2f);
        }

        // Encher combustível
        if (verificou && itemText.text == "Combustivel")
        {
            if (Input.GetKey(KeyCode.E))
            {
                enchendo = true;
                tempoEnchendo += Time.deltaTime;

                dialogueText.text = "ENCHENDO... " + Mathf.FloorToInt(tempoEnchendo) + "/5";

                if (tempoEnchendo >= 5f)
                {
                    itemText.text = "";
                    dialogueText.text = "Combustivel cheio!";
                    enabled = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                enchendo = false;
                tempoEnchendo = 0f;
            }
        }
    }

    void FalarNPC()
    {
        dialogueText.text = "Vou ficar consertando. Busque o combustivel atras da casa.";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;

            if (!verificou)
                dialogueText.text = "Pressione E para verificar";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;
            tempoEnchendo = 0f;
            dialogueText.text = "";
        }
    }
}
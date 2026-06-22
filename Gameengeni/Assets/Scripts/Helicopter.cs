using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Helicopter : MonoBehaviour
{
    private bool playerPerto = false;
    private bool verificou = false;
    private bool finalizando = false;
    private float tempoEnchendo = 0f;

    public TMP_Text dialogueText;
    public TMP_Text itemText;
    public FriendFollow friendFollow;

    void Update()
    {
        if (!playerPerto || finalizando)
            return;

        // Primeira interação: verificar helicóptero
        if (!verificou && Input.GetKeyDown(KeyCode.E))
        {
            verificou = true;
            dialogueText.text = "SEM COMBUSTIVEL!";

            if (friendFollow != null)
                friendFollow.PararSeguir();

            Invoke(nameof(FalarNPC), 2f);
        }

        // Abastecer helicóptero
        if (verificou && itemText.text == "Combustivel")
        {
            if (Input.GetKey(KeyCode.E))
            {
                tempoEnchendo += Time.deltaTime;

                dialogueText.text = "ENCHENDO... " + Mathf.FloorToInt(tempoEnchendo) + "/5";

                if (tempoEnchendo >= 5f)
                {
                    itemText.text = "";
                    finalizando = true;
                    dialogueText.text = "Combustivel cheio!";

                    Invoke(nameof(FinalDoJogo), 2f);
                }
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                tempoEnchendo = 0f;
            }
        }
    }

    void FalarNPC()
    {
        dialogueText.text = "Esta sem combustivel! Acho que havia um galao atras da casa onde estavamos. Va rapido, eu vou consertando.";
    }

    void FinalDoJogo()
    {
        dialogueText.text = "Vamos embora daqui!";
        Invoke(nameof(CarregarCenaWin), 2f);
    }

    void CarregarCenaWin()
    {
        SceneManager.LoadScene("WIN");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;

            if (!verificou)
            {
                dialogueText.text = "Pressione E para verificar";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;
            tempoEnchendo = 0f;

            if (!finalizando)
            {
                dialogueText.text = "";
            }
        }
    }
}
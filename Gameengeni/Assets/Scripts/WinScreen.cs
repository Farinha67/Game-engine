using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void VoltarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
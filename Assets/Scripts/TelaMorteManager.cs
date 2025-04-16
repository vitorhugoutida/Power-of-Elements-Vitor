using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaDeMorteManager : MonoBehaviour
{
    [Header("Nome da fase atual")]
    public string nomeDaFaseAtual;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReiniciarFase()
    {
        SceneManager.LoadScene(nomeDaFaseAtual);
    }

    public void ReiniciarFase2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void ReiniciarFase3()
    {
        SceneManager.LoadScene("Fase3");
    }

    public void ReiniciarJogoZero()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

}

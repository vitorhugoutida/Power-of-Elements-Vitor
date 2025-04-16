using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float vida = 3f;
    public Text vidaTexto;
    public VidaUI vidaUI;

    public bool isInvincible = false;

    private bool danoContinuoAtivo = false;

    [Header("Nome da fase atual")]
    public string nomeDaFaseParaGameOver;

    void Start()
    {
        AtualizarTexto();
    }

    public void LevarDano(float dano)
    {
        if (isInvincible)
        {
            //Debug.Log("Jogador está invencível. Não levou dano");
            return;
        }

        vida -= dano;
        AtualizarTexto();

        if (vida <= 0)
        {
            Morrer();
        }
    }




    void AtualizarTexto()
    {

        vidaUI.AtualizarVidaVisual(vida);


        // Vê se a divisão não sobra então true, muda o numero string sem virgula, se é falso, então mostra com virgula
        vidaTexto.text = "Vida: " + (vida % 1 == 0 ? vida.ToString("0") : vida.ToString("0.0"));

    }

    void Morrer()
    {
        //Debug.Log("O jogador morreu!");
        CenaAnterior.nomeDaCenaAnterior = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomeDaFaseParaGameOver);

    }

    public void AtivarDanoContinuo(float dano, float duracao)
    {
        if (!danoContinuoAtivo)
        {
            StartCoroutine(DanoAoLongoDoTempo(dano, duracao));
        }
    }

    System.Collections.IEnumerator DanoAoLongoDoTempo(float dano, float duracao)
    {
        danoContinuoAtivo = true;
        yield return new WaitForSeconds(duracao);
        LevarDano(dano);
        danoContinuoAtivo = false;
    }

    public void ActivateInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        Debug.Log("Jogador está invencível!");

        yield return new WaitForSeconds(duration);

        isInvincible = false;
        Debug.Log("Jogador voltou ao normal!");
    }

}

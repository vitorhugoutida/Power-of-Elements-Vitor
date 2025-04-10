using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float vida = 3f;
    public Text vidaTexto;

    private bool danoContinuoAtivo = false;

    void Start()
    {
        AtualizarTexto();
    }

    public void LevarDano(float dano)
    {
        vida -= dano;
        AtualizarTexto();

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void AtualizarTexto()
    {
        vidaTexto.text = "Vida: " + vida.ToString("0.0"); // mostra com 1 casa decimal
    }

    void Morrer()
    {
        Debug.Log("O jogador morreu!");
        // Aqui você pode reiniciar a fase, mostrar uma tela, etc.
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
}

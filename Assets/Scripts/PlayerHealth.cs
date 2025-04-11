using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float vida = 3f;
    public Text vidaTexto;
    public VidaUI vidaUI;



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

        vidaUI.AtualizarVidaVisual(vida);


        // Vê se a divisão não sobra então true, muda o numero string sem virgula, se é falso, então mostra com virgula
        vidaTexto.text = "Vida: " + (vida % 1 == 0 ? vida.ToString("0") : vida.ToString("0.0"));

    }

    void Morrer()
    {
        Debug.Log("O jogador morreu!");
        // Extra: Colocar tela de morte

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

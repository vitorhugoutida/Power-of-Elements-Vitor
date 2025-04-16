using UnityEngine;
using UnityEngine.UI;

public class InimigoVida : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaAtual;

    public Image barraDeVida;

    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarra();
    }

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;
        AtualizarBarra();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void AtualizarBarra()
    {
        if (barraDeVida != null)
        {
            barraDeVida.fillAmount = (float)vidaAtual / vidaMaxima;

        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}


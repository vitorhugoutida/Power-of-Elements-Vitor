using UnityEngine;
using UnityEngine.UI;

public class VidaUI : MonoBehaviour
{
    public Image[] coracoes;
    public Sprite cheio;
    public Sprite metade;

    public void AtualizarVidaVisual(float vida)
    {
        for (int i = 0; i < coracoes.Length; i++)
        {
            float valorCora��o = vida - i;

            if (valorCora��o >= 1)
            {
                coracoes[i].sprite = cheio;
                coracoes[i].enabled = true;
            }
            else if (valorCora��o >= 0.5f)
            {
                coracoes[i].sprite = metade;
                coracoes[i].enabled = true;
            }
            else
            {
                coracoes[i].enabled = false;
            }
        }
    }
}

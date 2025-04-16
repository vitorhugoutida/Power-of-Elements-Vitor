using UnityEngine;
using UnityEngine.UI;

public class CrystalCounter : MonoBehaviour
{
    public int totalCristaisColetados = 0;
    public int totalNecessario = 6;

    public Text cristalTexto;
    public GameObject avisoFinal;

    void Start()
    {
        AtualizarTexto();

        if (avisoFinal != null)
            avisoFinal.SetActive(false);
    }

    public void AdicionarCristal()
    {
        totalCristaisColetados++;
        AtualizarTexto();

        if (totalCristaisColetados >= totalNecessario)
        {
            if (avisoFinal != null)
                avisoFinal.SetActive(true);
        }
    }

    void AtualizarTexto()
    {
        cristalTexto.text = "Cristais: " + totalCristaisColetados;
    }
}

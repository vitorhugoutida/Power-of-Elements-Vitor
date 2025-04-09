using UnityEngine;
using UnityEngine.UI; // Para usar UI na tela

public class CrystalCounter : MonoBehaviour
{
    public int totalCristaisColetados = 0;
    public Text cristalTexto;

    void Start()
    {
        AtualizarTexto();
    }

    public void AdicionarCristal()
    {
        totalCristaisColetados++;
        AtualizarTexto();
    }

    void AtualizarTexto()
    {
        cristalTexto.text = "Cristais: " + totalCristaisColetados;
    }
}

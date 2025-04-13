using UnityEngine;
using UnityEngine.UI;

public class UIAviso : MonoBehaviour
{
    public Text textoAviso;

    public void MostrarAviso(string mensagem, float duracao)
    {
        StopAllCoroutines();
        StartCoroutine(MostrarTemporariamente(mensagem, duracao));
    }

    System.Collections.IEnumerator MostrarTemporariamente(string mensagem, float duracao)
    {
        textoAviso.text = mensagem;
        textoAviso.enabled = true;
        yield return new WaitForSeconds(duracao);
        textoAviso.enabled = false;
    }
}

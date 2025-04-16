using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalProximaFase : MonoBehaviour
{
    public UIAviso uiAviso;
    public string nomeDaProximaFase = "Fase2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrystalCounter contador = FindObjectOfType<CrystalCounter>();
            if (contador != null && contador.totalCristaisColetados >= contador.totalNecessario)
            {
                SceneManager.LoadScene(nomeDaProximaFase);
            }
            else
            {
                //Debug.Log("Ainda faltam cristais para avançar!");
                uiAviso.MostrarAviso("Ainda faltam cristais para avançar!", 3f);
            }
        }
    }
}

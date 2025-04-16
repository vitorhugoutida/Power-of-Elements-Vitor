using UnityEngine;

public class BotaoAbreCofre : MonoBehaviour
{
    public UIAviso uiAviso;
    public GameObject tampaDoCofre;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tampaDoCofre != null)
            {
                tampaDoCofre.SetActive(false);
                uiAviso.MostrarAviso("Cofre Desbloqueado!", 3f);

            }
        }
    }
}

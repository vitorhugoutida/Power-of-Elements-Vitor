using UnityEngine;

public class CrystalInvencibilidade : MonoBehaviour
{
    public UIAviso uiAviso;
    public float duracaoInvencibilidade = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                vida.ActivateInvincibility(duracaoInvencibilidade);
                uiAviso.MostrarAviso("Invencibilidade por 15 segundos!", 15f);

            }

            Destroy(gameObject);
        }
    }
}

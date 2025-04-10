using UnityEngine;

public class FogoDano : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                // Dano inicial
                vida.LevarDano(1f);
                // Dano contínuo após sair
                vida.AtivarDanoContinuo(0.5f, 1.5f);
            }
        }
    }
}

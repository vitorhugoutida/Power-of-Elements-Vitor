using UnityEngine;

public class BombaNuclear : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                vida.LevarDano(vida.vida);
            }

            Destroy(gameObject);
        }
    }
}

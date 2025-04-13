using UnityEngine;

public class CristalPulo : MonoBehaviour
{
    public UIAviso uiAviso;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAvancedMovimento mov = other.GetComponent<PlayerAvancedMovimento>();
            if (mov != null)
            {
                mov.AtivarPuloDuplo();

                if (uiAviso != null)
                {
                    uiAviso.MostrarAviso("Pulo duplo desbloqueado!", 3f);
                }

                Destroy(gameObject);
            }
        }
    }
}

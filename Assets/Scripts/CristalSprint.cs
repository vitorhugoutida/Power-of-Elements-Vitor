using UnityEngine;

public class CristalSprint : MonoBehaviour
{
    public UIAviso uiAviso;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAvancedMovimento mov = other.GetComponent<PlayerAvancedMovimento>();
            if (mov != null)
            {
                mov.AtivarSprint();

                if (uiAviso != null)
                {
                    uiAviso.MostrarAviso("Sprint desbloqueado!", 3f);
                }

                Destroy(gameObject);
            }
        }
    }
}

using UnityEngine;

public class CristalSprint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAvancedMovimento mov = other.GetComponent<PlayerAvancedMovimento>();
            if (mov != null)
            {
                mov.AtivarSprint();
                Destroy(gameObject);
            }
        }
    }
}

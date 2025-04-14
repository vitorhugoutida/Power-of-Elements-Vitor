using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform destino;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && destino != null)
        {
            other.transform.position = destino.position;
        }
    }
}

using UnityEngine;

public class SlimeAtaque : MonoBehaviour
{
    public float dano = 1f;
    public float tempoEntreAtaques = 1f;
    private float tempoDoUltimoAtaque = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();

            if (vida != null && Time.time > tempoDoUltimoAtaque + tempoEntreAtaques)
            {
                vida.LevarDano(dano);
                tempoDoUltimoAtaque = Time.time;
                //Debug.Log("Slime atacou player");
            }
        }
    }
}

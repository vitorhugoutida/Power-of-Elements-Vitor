using UnityEngine;

public class AguaDano : MonoBehaviour
{
    public float tempoParaDanoExtra = 3f;
    public float danoInicial = 1f;
    public float danoDepois = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();
            if (vida != null)
            {
                vida.LevarDano(danoInicial);
                vida.StartCoroutine(AplicaDanoDepoisDeTempo(vida));
            }

            PlayerAvancedMovimento mov = other.GetComponent<PlayerAvancedMovimento>();
            if (mov != null)
            {
                mov.emAgua = true;
            }
        }

    }

    private System.Collections.IEnumerator AplicaDanoDepoisDeTempo(PlayerHealth vida)
    {
        yield return new WaitForSeconds(tempoParaDanoExtra);
        vida.LevarDano(danoDepois);
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAvancedMovimento player = other.GetComponent<PlayerAvancedMovimento>();
            if (player != null)
            {
                player.emAgua = false;
            }

        }
    }

}



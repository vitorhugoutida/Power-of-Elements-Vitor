using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform jogador;
    public float velocidade = 3f;
    public float distanciaParaParar = 1.5f;

    void Update()
    {
        if (jogador == null) return;

        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia > distanciaParaParar)
        {
            Vector3 direcao = (jogador.position - transform.position).normalized;
            transform.position += direcao * velocidade * Time.deltaTime;

            transform.LookAt(new Vector3(jogador.position.x, transform.position.y, jogador.position.z));
        }
    }
}

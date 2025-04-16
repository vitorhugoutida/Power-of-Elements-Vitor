using UnityEngine;

public class ChaoDesapareceEVolta : MonoBehaviour
{
    public float tempoParaDesaparecer = 2f;
    public float tempoParaVoltar = 8f;

    private bool ativado = false;
    private float tempoAtual = 0f;
    private Renderer rend;
    private Collider col;

    private Color corOriginal;
    private bool sumiu = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        corOriginal = rend.material.color;
    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.CompareTag("Player") && !ativado)
        {
            ativado = true;
            tempoAtual = 0f;
        }
    }

    void Update()
    {
        if (ativado)
        {
            tempoAtual += Time.deltaTime;

            if (!sumiu)
            {
                float alpha = Mathf.Lerp(1f, 0f, tempoAtual / tempoParaDesaparecer);
                SetAlpha(alpha);

                if (tempoAtual >= tempoParaDesaparecer)
                {
                    rend.enabled = false;
                    col.enabled = false;
                    sumiu = true;
                    tempoAtual = 0f;
                }
            }
            else
            {
                if (tempoAtual >= tempoParaVoltar)
                {
                    rend.enabled = true;
                    col.enabled = true;
                    SetAlpha(1f);

                    ativado = false;
                    sumiu = false;
                    tempoAtual = 0f;
                }
            }
        }
    }

    void SetAlpha(float alpha)
    {
        Color novaCor = corOriginal;
        novaCor.a = alpha;
        rend.material.color = novaCor;
    }
}

using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    public float distanciaDoAtaque = 2f;
    public int dano = 1;
    public GameObject efeitoDeImpacto;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaDoAtaque))
            {
                if (hit.collider.CompareTag("Inimigo"))
                {
                    if (efeitoDeImpacto != null)
                    {
                        Instantiate(efeitoDeImpacto, hit.point, Quaternion.identity);
                    }

                    InimigoVida inimigo = hit.collider.GetComponent<InimigoVida>();
                    if (inimigo != null)
                    {
                        inimigo.LevarDano(dano);
                    }
                }
            }
        }
    }
}

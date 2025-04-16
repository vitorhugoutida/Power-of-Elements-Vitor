using UnityEngine;

public class CrystalCollect : MonoBehaviour
{
    public UIAviso uiAviso;

    public float rotateSpeed = 100f;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Cristal coletado");

            uiAviso.MostrarAviso("Cristal Coletado!", 3f);

            FindObjectOfType<CrystalCounter>().AdicionarCristal();

            Destroy(gameObject);
        }
    }
}

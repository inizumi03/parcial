using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curarse : MonoBehaviour

{
    public float CantidadCura;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Salud>())
        {
            other.GetComponent<Salud>().RecivirCura(CantidadCura);

            Destroy(gameObject);
        }
    }
}



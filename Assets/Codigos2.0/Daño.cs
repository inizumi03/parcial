using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& other.GetComponent<Salud>())
        {
            other.GetComponent<Salud>().RecivirDaño(CantidadDaño);
        }
    }
}

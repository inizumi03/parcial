using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otrodaño : MonoBehaviour
{
    public float CantidadDaño;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Salud>())
        {
            collision.gameObject.GetComponent<Salud>().RecivirDaño(CantidadDaño);
        }
    }

}

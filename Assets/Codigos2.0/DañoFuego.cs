using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoFuego : MonoBehaviour

{
    [SerializeField] private float daño = 10f; // Cantidad de daño a aplicar
    [SerializeField] private float fuerzaEmpuje = 5f; // Fuerza de empuje hacia atrás

    private void OnTriggerEnter(Collider other)
    {
        VidaEnemiga vidaEnemiga = other.GetComponent<VidaEnemiga>();
        if (vidaEnemiga != null)
        {
            vidaEnemiga.TomarDaño(daño);

            // Aplicar fuerza de empuje hacia atrás
            Rigidbody rbEnemigo = other.GetComponent<Rigidbody>();
            if (rbEnemigo != null)
            {
                Vector3 direccionEmpuje = other.transform.position - transform.position;
                direccionEmpuje.y = 0; // Opcional: mantener la fuerza horizontal
                direccionEmpuje.Normalize();
                rbEnemigo.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
            }
        }
    }
}



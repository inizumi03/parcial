using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoDaño : MonoBehaviour

{
    [SerializeField] private float daño = 10f; // Cantidad de daño a aplicar
    [SerializeField] private float fuerzaEmpuje = 5f; // Fuerza de empuje hacia atrás

    private void OnCollisionEnter(Collision collision)
    {
        // Intenta obtener el componente SaludJose
        SaludJose saludEnemiga = collision.collider.GetComponent<SaludJose>();
        if (saludEnemiga != null)
        {
            saludEnemiga.TomarDaño(daño);

            // Aplicar fuerza de empuje hacia atrás
            Rigidbody rbEnemigo = collision.collider.GetComponent<Rigidbody>();
            if (rbEnemigo != null)
            {
                Vector3 direccionEmpuje = collision.transform.position - transform.position;
                direccionEmpuje.y = 0; // Opcional: mantener la fuerza horizontal
                direccionEmpuje.Normalize();
                rbEnemigo.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
            }
            return; // Salir después de aplicar daño para evitar aplicar daño a ambos componentes
        }

        // Intenta obtener el componente VidaEnemiga si no se encontró SaludJose
        VidaEnemiga vidaEnemiga = collision.collider.GetComponent<VidaEnemiga>();
        if (vidaEnemiga != null)
        {
            vidaEnemiga.TomarDaño(daño);

            // Aplicar fuerza de empuje hacia atrás
            Rigidbody rbEnemigo = collision.collider.GetComponent<Rigidbody>();
            if (rbEnemigo != null)
            {
                Vector3 direccionEmpuje = collision.transform.position - transform.position;
                direccionEmpuje.y = 0; // Opcional: mantener la fuerza horizontal
                direccionEmpuje.Normalize();
                rbEnemigo.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
            }
        }
    }
}





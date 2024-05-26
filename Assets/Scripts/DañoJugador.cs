using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoJugador : MonoBehaviour
{
    public float cantidadDaño = 10f; // Cantidad de daño que inflige este objeto

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto colisionado tiene la etiqueta "Enemigo" y un componente "SaludEnemigo"
        if (collision.gameObject.CompareTag("Enemigo") && collision.gameObject.GetComponent<SaludEnemigos>())
        {
            // Llamar al método RecibirDaño del componente SaludEnemigo del enemigo
            collision.gameObject.GetComponent<SaludEnemigos>().RecibirDaño(cantidadDaño);
        }
    }
}

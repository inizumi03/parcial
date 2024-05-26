using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LogicaDeEnemigos : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento de los enemigos

    private void Update()
    {
        // Verificar si hay un jugador activo asignado
        if (CambiarPJ.jugadorActivo != null)
        {
            Transform jugadorActivo = CambiarPJ.jugadorActivo.transform;

            // Calcular la dirección hacia el jugador activo
            Vector3 direccion = (jugadorActivo.position - transform.position).normalized;

            // Calcular el movimiento basado en la dirección y la velocidad
            Vector3 movimiento = direccion * velocidadMovimiento * Time.deltaTime;

            // Mover al enemigo hacia el jugador activo
            transform.Translate(movimiento);
        }
    }
}

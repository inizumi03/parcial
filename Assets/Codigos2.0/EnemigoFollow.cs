using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFollow : MonoBehaviour


{
    public float speed = 2f; // Velocidad de movimiento del enemigo
    public Transform jugador1; // Referencia al transform del jugador 1
    public Transform jugador2; // Referencia al transform del jugador 2
    public float distanciaDeteccion = 15f; // Distancia máxima para detectar a los jugadores

    private Transform objetivoActual; // Referencia al jugador que el enemigo está persiguiendo

    private void Update()
    {
        // Verifica la distancia entre el enemigo y los jugadores
        float distanciaAlJugador1 = Vector3.Distance(transform.position, jugador1.position);
        float distanciaAlJugador2 = Vector3.Distance(transform.position, jugador2.position);

        // Determina el objetivo actual como el jugador más cercano dentro del rango de detección
        if (distanciaAlJugador1 < distanciaAlJugador2 && distanciaAlJugador1 < distanciaDeteccion)
        {
            objetivoActual = jugador1;
        }
        else if (distanciaAlJugador2 < distanciaAlJugador1 && distanciaAlJugador2 < distanciaDeteccion)
        {
            objetivoActual = jugador2;
        }
        else
        {
            objetivoActual = null; // Si ningún jugador está dentro del rango de detección, el enemigo no tiene objetivo
        }

        // Mueve el enemigo hacia el objetivo actual si hay uno
        if (objetivoActual != null)
        {
            Vector3 direccion = (objetivoActual.position - transform.position).normalized;
            Vector3 nuevaPosicion = transform.position + (direccion * speed * Time.deltaTime);

            // Mantén la altura del enemigo
            nuevaPosicion.y = transform.position.y;

            // Mueve al enemigo hacia la nueva posición
            transform.position = nuevaPosicion;
        }
    }
}








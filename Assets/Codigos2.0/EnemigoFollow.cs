using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFollow : MonoBehaviour

{
    public float speed = 2f;  // Velocidad de movimiento del enemigo
    public float distanciaDeteccion = 10f;  // Distancia m�xima para detectar a los jugadores
    public float rotacionSuavizado = 5f;  // Factor de suavizado para la rotaci�n
    public Transform jugador1;  // Referencia al primer jugador
    public Transform jugador2;  // Referencia al segundo jugador
    public bool seguirJugador1 = true;  // Flag para decidir cu�l jugador seguir

    private Transform objetivo;  // Variable para almacenar la referencia al jugador activo

    private void Start()
    {
        // Inicializar el objetivo con el jugador activo
        ActualizarObjetivo();
    }

    private void Update()
    {
        if (objetivo != null)
        {
            // Obtener la direcci�n hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Mover el enemigo hacia el objetivo
            MoverHaciaObjetivo(direccion);

            // Suavizar la rotaci�n del enemigo hacia el objetivo
            RotarHaciaObjetivo(direccion);
        }
    }

    private void ActualizarObjetivo()
    {
        // Verifica cu�l jugador debe ser seguido basado en el flag
        if (seguirJugador1 && jugador1 != null)
        {
            objetivo = jugador1;
        }
        else if (!seguirJugador1 && jugador2 != null)
        {
            objetivo = jugador2;
        }
        else
        {
            objetivo = null;  // No hay objetivo si ninguno est� asignado
        }
    }

    private void OnEnable()
    {
        // Actualizar el objetivo cuando el objeto se habilita
        ActualizarObjetivo();
    }

    private void OnDisable()
    {
        // Opcional: Limpiar la referencia del objetivo si el enemigo se desactiva
        objetivo = null;
    }

    private void MoverHaciaObjetivo(Vector3 direccion)
    {
        // Mueve el enemigo hacia el objetivo con un movimiento m�s suave
        float distancia = Vector3.Distance(transform.position, objetivo.position);
        if (distancia < distanciaDeteccion)  // Solo mover si est� dentro del rango de detecci�n
        {
            // Calcula la nueva posici�n
            Vector3 nuevaPosicion = transform.position + direccion * speed * Time.deltaTime;

            // Asegura que el enemigo se mueve en el plano horizontal
            nuevaPosicion.y = transform.position.y;

            // Actualiza la posici�n del enemigo
            transform.position = nuevaPosicion;
        }
    }

    private void RotarHaciaObjetivo(Vector3 direccion)
    {
        // Calcula la rotaci�n deseada hacia el objetivo sin apuntar hacia la c�mara
        Quaternion rotacionDeseada = Quaternion.LookRotation(direccion, Vector3.up);

        // Suaviza la rotaci�n del enemigo hacia el objetivo
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, rotacionSuavizado * Time.deltaTime);
    }
}






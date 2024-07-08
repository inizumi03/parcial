using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFollow : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del enemigo
    public float distanciaDeteccion = 10f; // Distancia máxima para detectar al jugador
    private Transform objetivo; // Variable para almacenar la referencia al jugador activo

    private void Start()
    {
        // Inicializar el objetivo con el jugador activo
        ActualizarObjetivo();
    }

    private void Update()
    {
        if (objetivo != null)
        {
            // Obtener la dirección hacia el objetivo
            Vector3 direccion = (objetivo.position - transform.position).normalized;

            // Mover el enemigo hacia el objetivo
            transform.position += direccion * speed * Time.deltaTime;

            // Mirar hacia el objetivo
            transform.LookAt(new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z));
        }
    }

    private void ActualizarObjetivo()
    {
        // Verificar si el jugador activo está disponible
        if (CambiarPJ2.jugadorActivo != null)
        {
            // Obtener el objetivo del jugador activo
            objetivo = CambiarPJ2.jugadorActivo.transform;
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
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoseMOV : MonoBehaviour
{

    public Transform[] puntosDeMovimiento; // Array de puntos de destino
    public float velocidad = 2f; // Velocidad de movimiento
    public float velocidadAnimacion = 1f; // Escala para la velocidad de animación
    public float distanciaDeDetencion = 0.5f; // Distancia a la que el enemigo se detiene
    public float tiempoEspera = 3f; // Tiempo de espera en segundos
    public float tiempoEsperaSinPuntos = 1f; // Tiempo de espera si no hay puntos

    private Animator animator;
    private int puntoActual = 0;
    private Vector3 destino;
    private bool esperando = false;
    private float tiempoEsperaRestante;

    void Start()
    {
        if (puntosDeMovimiento.Length > 0)
        {
            destino = puntosDeMovimiento[puntoActual].position;
        }
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!esperando)
        {
            Mover();
        }
        else
        {
            TiempoDeEspera();
        }
        ActualizarAnimaciones();
    }

    private void Mover()
    {
        if (puntosDeMovimiento.Length == 0) return;

        // Mueve el enemigo hacia el destino
        Vector3 direccion = (destino - transform.position).normalized;
        Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        nuevaPosicion.y = transform.position.y; // Mantener la posición en el eje Y constante
        transform.position = nuevaPosicion;

        // Rota el modelo para mirar en la dirección de movimiento
        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidad * Time.deltaTime);
        }

        // Verifica si el enemigo ha llegado cerca del destino
        if (Vector3.Distance(transform.position, destino) < distanciaDeDetencion)
        {
            esperando = true; // Inicia el temporizador de espera
            tiempoEsperaRestante = tiempoEspera;

            // Cambia al siguiente punto
            if (puntosDeMovimiento.Length > 0)
            {
                puntoActual = (puntoActual + 1) % puntosDeMovimiento.Length;
                destino = puntosDeMovimiento[puntoActual].position;
            }
        }
    }

    private void TiempoDeEspera()
    {
        tiempoEsperaRestante -= Time.deltaTime;

        if (tiempoEsperaRestante <= 0)
        {
            esperando = false;

            // Si no hay puntos, espera el tiempo especificado y vuelve al primer punto
            if (puntosDeMovimiento.Length == 0)
            {
                tiempoEsperaRestante = tiempoEsperaSinPuntos;
            }
        }
    }

    private void ActualizarAnimaciones()
    {
        // Calcula la velocidad en los ejes X y Z
        float velX = Mathf.Abs(destino.x - transform.position.x) / Time.deltaTime;
        float velY = Mathf.Abs(destino.z - transform.position.z) / Time.deltaTime;

        // Actualiza los parámetros de animación
        animator.SetFloat("Velx", velX * velocidadAnimacion);
        animator.SetFloat("Vely", velY * velocidadAnimacion);
    }
}



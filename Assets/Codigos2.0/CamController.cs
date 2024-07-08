using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour


{
    public Transform tony; // Referencia al transform de Tony
    public Transform sun;  // Referencia al transform de Sun
    public Transform jugador; // Referencia al transform del jugador activo
    public float suavizado = 0.125f; // Suavizado del movimiento de la cámara
    public Vector3 offset = new Vector3(0, 0, -10); // Desplazamiento inicial de la cámara respecto al jugador
    public bool seguirHorizontalmente = true; // Permitir seguimiento horizontal
    public bool seguirVerticalmente = true; // Permitir seguimiento vertical

    void Start()
    {
        // Asegúrate de que la cámara siga al jugador al inicio
        jugador = sun; // Por defecto, empieza con Sun
    }

    void Update()
    {
        // Detectar cambios de personaje
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarAActor(sun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarAActor(tony);
        }
    }

    void LateUpdate()
    {
        if (jugador == null)
        {
            Debug.LogError("Falta asignar el jugador en el script CamController");
            return;
        }

        // Calcular la posición deseada de la cámara con el offset
        Vector3 posicionDeseada = jugador.position + offset;

        // Ajustar la posición deseada según las opciones de seguimiento
        Vector3 posicionActual = transform.position;
        if (!seguirHorizontalmente)
        {
            posicionDeseada.x = posicionActual.x;
        }
        if (!seguirVerticalmente)
        {
            posicionDeseada.y = posicionActual.y;
        }

        // Suavizar el movimiento de la cámara
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado);

        // Asignar la posición suavizada a la cámara
        transform.position = posicionSuavizada;
    }

    private void CambiarAActor(Transform nuevoJugador)
    {
        if (nuevoJugador != jugador)
        {
            jugador = nuevoJugador;
        }
    }
}




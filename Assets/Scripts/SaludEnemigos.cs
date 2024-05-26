using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigos : MonoBehaviour
{
    public float vidaMaxima = 100f; // Vida máxima del enemigo
    private float vidaActual; // Vida actual del enemigo

    void Start()
    {
        vidaActual = vidaMaxima; // Al inicio, la vida actual es igual a la vida máxima
    }

    public void RecibirDaño(float cantidadDaño)
    {
        // Restar la cantidad de daño a la vida actual
        vidaActual -= cantidadDaño;

        // Verificar si la vida actual es menor o igual a cero
        if (vidaActual <= 0)
        {
            // Destruir el objeto enemigo si la vida llega a cero o menos
            Destroy(gameObject);
        }
    }
}

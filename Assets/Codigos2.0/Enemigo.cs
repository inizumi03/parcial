using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida; // Vida inicial del enemigo

    void Start()
    {
        // Aqu� podr�as inicializar la vida si es necesario
    }

    // M�todo para recibir da�o
    public void TomarDa�o(float da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
            Morir();
        }
    }

    // M�todo para acciones cuando el enemigo muere
    void Morir()
    {
        // Ejemplo: Destruir el objeto del enemigo, reproducir una animaci�n, etc.
        Debug.Log("El enemigo ha sido derrotado.");
        Destroy(gameObject); // Destruir el objeto del enemigo
    }
}

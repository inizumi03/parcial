using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida; // Vida inicial del enemigo

    void Start()
    {
        // Aquí podrías inicializar la vida si es necesario
    }

    // Método para recibir daño
    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Morir();
        }
    }

    // Método para acciones cuando el enemigo muere
    void Morir()
    {
        // Ejemplo: Destruir el objeto del enemigo, reproducir una animación, etc.
        Debug.Log("El enemigo ha sido derrotado.");
        Destroy(gameObject); // Destruir el objeto del enemigo
    }
}

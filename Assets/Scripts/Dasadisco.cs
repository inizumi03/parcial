using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasadisco : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo despu�s del cual se destruir� el objeto

    void Start()
    {
        // Destruye el objeto despu�s de un tiempo especificado
        Destroy(gameObject, destroyTime);
    }

    // Este m�todo se llama cuando el disco colisiona con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto tiene la etiqueta "Pared", destr�yelo
        if (other.CompareTag("Pared"))
        {
            Destroy(other.gameObject); // Destruye el objeto pared
            Destroy(gameObject); // Destruye el disco
        }
    }
}


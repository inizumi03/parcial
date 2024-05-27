using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasadisco : MonoBehaviour
{
    public float destroyTime = 2f; // Tiempo después del cual se destruirá el objeto

    void Start()
    {
        // Destruye el objeto después de un tiempo especificado
        Destroy(gameObject, destroyTime);
    }

    // Este método se llama cuando el disco colisiona con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto tiene la etiqueta "Pared", destrúyelo
        if (other.CompareTag("Pared"))
        {
            Destroy(other.gameObject); // Destruye el objeto pared
            Destroy(gameObject); // Destruye el disco
        }
    }
}


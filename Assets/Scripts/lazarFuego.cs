using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarFuego : MonoBehaviour
{
    public GameObject prefabDisparo; // Prefab que se lanzar� al presionar la tecla 'E'
    public Transform puntoOrigen; // Objeto vac�o que servir� como punto de origen del fuego
    private GameObject prefabInstance; // Instancia del prefab lanzado

    void Update()
    {
        // Si se presiona la tecla 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Instancia el prefab de disparo si a�n no existe una instancia activa
            if (prefabInstance == null)
            {
                prefabInstance = Instantiate(prefabDisparo, puntoOrigen.position, puntoOrigen.rotation);
            }
        }

        // Si se suelta la tecla 'E'
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Destruye la instancia del prefab si existe
            if (prefabInstance != null)
            {
                Destroy(prefabInstance);
                prefabInstance = null;
            }
        }
    }
}




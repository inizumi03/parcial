using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazarFuego : MonoBehaviour

{
    public GameObject prefabDisparo; // Prefab que se lanzará al presionar la tecla 'E'
    private GameObject prefabInstance; // Instancia del prefab lanzado

    void Update()
    {
        // Si se presiona la tecla 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Instancia el prefab de disparo si aún no existe una instancia activa
            if (prefabInstance == null)
            {
                prefabInstance = Instantiate(prefabDisparo, transform.position, transform.rotation);
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



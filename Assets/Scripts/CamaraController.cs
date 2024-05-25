using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour


{
    public Transform player;    // Referencia al transform del jugador
    public Vector3 offset;      // Desplazamiento de la cámara respecto al jugador

    void Start()
    {
        // Puedes ajustar el offset inicial si no lo has hecho en el Inspector
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        // Actualizar la posición de la cámara para seguir al jugador
        transform.position = player.position + offset;
    }
}


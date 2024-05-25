using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour


{
    public Transform player;    // Referencia al transform del jugador
    public Vector3 offset;      // Desplazamiento de la c�mara respecto al jugador

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
        // Actualizar la posici�n de la c�mara para seguir al jugador
        transform.position = player.position + offset;
    }
}


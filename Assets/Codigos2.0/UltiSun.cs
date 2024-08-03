using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiSun : MonoBehaviour
{
    public GameObject prefabUlti; // Prefab que será instanciado
    public Transform puntoDeInvocacion; // Punto específico de invocación

    public void EjecutarUlti()
    {
        // Instanciar el prefab en el punto de invocación
        if (prefabUlti != null && puntoDeInvocacion != null)
        {
            Instantiate(prefabUlti, puntoDeInvocacion.position, puntoDeInvocacion.rotation);
        }
    }
}


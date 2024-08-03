using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiSun : MonoBehaviour
{
    public GameObject prefabUlti; // Prefab que ser� instanciado
    public Transform puntoDeInvocacion; // Punto espec�fico de invocaci�n

    public void EjecutarUlti()
    {
        // Instanciar el prefab en el punto de invocaci�n
        if (prefabUlti != null && puntoDeInvocacion != null)
        {
            Instantiate(prefabUlti, puntoDeInvocacion.position, puntoDeInvocacion.rotation);
        }
    }
}


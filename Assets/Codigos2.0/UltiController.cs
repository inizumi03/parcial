using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiController : MonoBehaviour
 
{
    public GameObject pinchosPrefab; // El prefab de los pinchos
    public Transform spawnPoint;     // El punto de generaci�n de los pinchos

    // Este m�todo se llamar� cuando se active la funci�n Ulti en MOVcrontrollerTony
    public void ActivarUlti()
    {
        if (pinchosPrefab != null && spawnPoint != null)
        {
            // Generar el prefab de los pinchos en el punto de generaci�n
            Instantiate(pinchosPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}



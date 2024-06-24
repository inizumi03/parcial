using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiController : MonoBehaviour
 
{
    public GameObject pinchosPrefab; // El prefab de los pinchos
    public Transform spawnPoint;     // El punto de generación de los pinchos

    // Este método se llamará cuando se active la función Ulti en MOVcrontrollerTony
    public void ActivarUlti()
    {
        if (pinchosPrefab != null && spawnPoint != null)
        {
            // Generar el prefab de los pinchos en el punto de generación
            Instantiate(pinchosPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}



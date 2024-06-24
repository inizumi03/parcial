using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarYPausar : MonoBehaviour
{
   
    public GameObject prefab; // Prefab que se va a instanciar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            InstanciarPrefab();
            PausarJuego();
        }
    }

    void InstanciarPrefab()
    {
        if (prefab != null)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity); // Instanciar el prefab en la posición (0, 0, 0)
        }
        else
        {
            Debug.LogError("Prefab no asignado en el inspector");
        }
    }

    void PausarJuego()
    {
        Time.timeScale = 0; // Pausar el juego
    }
}


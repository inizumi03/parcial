using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiSController : MonoBehaviour
{
    public float activationTime = 3f; // Tiempo antes de empezar a activarse y desactivarse
    public float destructionTime = 4f; // Tiempo antes de destruir el prefab
    public float blinkInterval = 0.1f; // Intervalo de parpadeo

    void Start()
    {
        // Inicia la secuencia de activación y destrucción
        Invoke("StartBlinking", activationTime);
        Destroy(gameObject, destructionTime);
    }

    void StartBlinking()
    {
        InvokeRepeating("ToggleVisibility", 0f, blinkInterval);
    }

    void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}


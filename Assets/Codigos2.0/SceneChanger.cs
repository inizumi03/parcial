using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Método que se llama cuando otro collider entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Cambia a la escena "PlataformerScene"
            SceneManager.LoadScene("PlataformerScene");
        }
    }
}


 


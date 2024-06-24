using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // M�todo para cargar la escena "Plataformer"
    void Update()
    {
        // Cambia la escena cuando se presiona la tecla "P"
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Plataformerscene");
        }
    }
}


 


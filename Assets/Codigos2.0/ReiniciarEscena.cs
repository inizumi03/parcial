using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarEscena : MonoBehaviour


{
    public KeyCode teclaReinicio = KeyCode.R;  // Tecla para reiniciar la escena, configurable desde el Inspector

    void Update()
    {
        // Detectar si la tecla configurada es presionada
        if (Input.GetKeyDown(teclaReinicio))
        {
            Reiniciar();
        }
    }

    void Reiniciar()
    {
        // Obtiene el nombre de la escena actual
        string nombreEscena = SceneManager.GetActiveScene().name;

        // Vuelve a cargar la escena actual
        SceneManager.LoadScene(nombreEscena);
    }
}




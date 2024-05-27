using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDelJuego : MonoBehaviour
{
    public GameObject prefab; // Prefab a instanciar
    public Vector3 posicionInstanciar; // Posición donde se instanciará el prefab
    public GameObject objetoADestruir; // Objeto que se destruirá

    void Update()
    {
        if (objetoADestruir == null) // Comprueba si el objeto ya ha sido destruido
        {
            InstanciarPrefab();
            PausarJuego();
        }
    }

    void InstanciarPrefab()
    {
        Instantiate(prefab, posicionInstanciar, Quaternion.identity);
    }

    void PausarJuego()
    {
        Time.timeScale = 0; // Pausa el juego
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPrefabs : MonoBehaviour

{
    [Header("Configuraci�n del Generador")]
    public GameObject[] prefabs;  // Array de prefabs a instanciar (arr�stralos aqu� desde Assets)
    public Transform[] puntosInstanciacion;  // Array de puntos de instanciaci�n (arr�stralos aqu� desde la jerarqu�a)

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            GenerarPrefabs();  // Llama al m�todo para generar prefabs
        }
    }

    private void GenerarPrefabs()
    {
        // Verifica que hay puntos de instanciaci�n disponibles
        if (puntosInstanciacion.Length == 0)
        {
            Debug.LogWarning("No hay puntos de instanciaci�n asignados.");
            return;
        }

        // Verifica que hay prefabs disponibles
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("No hay prefabs asignados.");
            return;
        }

        // Verifica que la cantidad de prefabs es igual a la cantidad de puntos de instanciaci�n
        if (prefabs.Length != puntosInstanciacion.Length)
        {
            Debug.LogWarning("El n�mero de prefabs debe ser igual al n�mero de puntos de instanciaci�n.");
            return;
        }

        // Genera los prefabs en los puntos de instanciaci�n correspondientes
        for (int i = 0; i < prefabs.Length; i++)
        {
            // Selecciona un prefab espec�fico para el punto de instanciaci�n correspondiente
            GameObject prefab = prefabs[i];
            Transform punto = puntosInstanciacion[i];

            // Instancia el prefab en la posici�n y rotaci�n del punto
            Instantiate(prefab, punto.position, punto.rotation);
        }
    }
}





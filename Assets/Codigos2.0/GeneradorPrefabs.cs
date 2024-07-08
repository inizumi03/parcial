using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPrefabs : MonoBehaviour

{
    [Header("Configuración del Generador")]
    public GameObject[] prefabs;  // Array de prefabs a instanciar (arrástralos aquí desde Assets)
    public Transform[] puntosInstanciacion;  // Array de puntos de instanciación (arrástralos aquí desde la jerarquía)

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            GenerarPrefabs();  // Llama al método para generar prefabs
        }
    }

    private void GenerarPrefabs()
    {
        // Verifica que hay puntos de instanciación disponibles
        if (puntosInstanciacion.Length == 0)
        {
            Debug.LogWarning("No hay puntos de instanciación asignados.");
            return;
        }

        // Verifica que hay prefabs disponibles
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("No hay prefabs asignados.");
            return;
        }

        // Verifica que la cantidad de prefabs es igual a la cantidad de puntos de instanciación
        if (prefabs.Length != puntosInstanciacion.Length)
        {
            Debug.LogWarning("El número de prefabs debe ser igual al número de puntos de instanciación.");
            return;
        }

        // Genera los prefabs en los puntos de instanciación correspondientes
        for (int i = 0; i < prefabs.Length; i++)
        {
            // Selecciona un prefab específico para el punto de instanciación correspondiente
            GameObject prefab = prefabs[i];
            Transform punto = puntosInstanciacion[i];

            // Instancia el prefab en la posición y rotación del punto
            Instantiate(prefab, punto.position, punto.rotation);
        }
    }
}





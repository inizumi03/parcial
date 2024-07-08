using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoAutomatico : MonoBehaviour

{
    [Header("Configuraci�n del Disparo")]
    public GameObject prefab;  // Prefab a disparar (arr�stralo aqu� desde Assets)
    public Transform puntoDisparo;  // Punto desde donde se dispara el prefab (arr�stralo aqu� desde la jerarqu�a)
    public float intervaloDisparo = 1f;  // Intervalo entre disparos en segundos
    public float fuerzaDisparo = 10f;  // Fuerza aplicada al prefab al disparar
    public float duracionPrefab = 5f;  // Tiempo en segundos antes de destruir el prefab

    private void Start()
    {
        // Llama al m�todo para empezar a disparar autom�ticamente
        StartCoroutine(DispararAutomaticamente());
    }

    private IEnumerator DispararAutomaticamente()
    {
        while (true)
        {
            // Instancia el prefab en el punto de disparo
            GameObject nuevoPrefab = Instantiate(prefab, puntoDisparo.position, puntoDisparo.rotation);

            // Aplica una fuerza al prefab para dispararlo
            Rigidbody rb = nuevoPrefab.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(puntoDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
            }

            // Destruye el prefab despu�s de un tiempo
            Destroy(nuevoPrefab, duracionPrefab);

            // Espera el intervalo de disparo antes de disparar de nuevo
            yield return new WaitForSeconds(intervaloDisparo);
        }
    }
}
 


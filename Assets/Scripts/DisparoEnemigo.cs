using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisparoEnemigo : MonoBehaviour
{
    public GameObject prefabBala; // Prefab de la bala a instanciar
    public Transform puntoDisparo; // Punto de origen del disparo
    public float fuerzaDisparo = 10f; // Fuerza del disparo
    public float tiempoEntreDisparos = 15f; // Tiempo entre cada disparo
    public float tiempoDestruccionBala = 3f; // Tiempo de vida de la bala

    private float tiempoUltimoDisparo;

    void Start()
    {
        tiempoUltimoDisparo = Time.time;
    }

    void Update()
    {
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        // Direccion de disparo fija (hacia adelante)
        Vector3 direccionDisparo = puntoDisparo.forward;

        // Instancia la bala en el punto de disparo
        GameObject bala = Instantiate(prefabBala, puntoDisparo.position, Quaternion.LookRotation(direccionDisparo));

        // Agrega fuerza a la bala
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.Impulse);
        }

        // Destruye la bala después de un tiempo
        Destroy(bala, tiempoDestruccionBala);
    }
}

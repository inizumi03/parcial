using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueSun : MonoBehaviour


{
    public GameObject aquaSunPrefab; // Prefab del proyectil
    public Transform disparoPosicion; // Posición desde la cual se dispara el proyectil
    public float fuerzaDisparo = 10f; // Fuerza con la que se dispara el proyectil
    public float tiempoVidaBala = 2f; // Tiempo de vida del proyectil

    public void Disparar()
    {
        if (aquaSunPrefab != null && disparoPosicion != null)
        {
            GameObject proyectil = Instantiate(aquaSunPrefab, disparoPosicion.position, disparoPosicion.rotation);
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(disparoPosicion.forward * fuerzaDisparo, ForceMode.Impulse);
            }
            Destroy(proyectil, tiempoVidaBala);
        }
    }
}





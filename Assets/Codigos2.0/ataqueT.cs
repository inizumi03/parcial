using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueT : MonoBehaviour
{
    [SerializeField] private GameObject golpeCollider; // Referencia al objeto del collider de golpe

    private void Start()
    {
        // Desactivar el collider de golpe al inicio
        golpeCollider.SetActive(false);
    }

    private void Update()
    {
        // Detectar el evento de inicio de golpe
        if (Input.GetMouseButtonDown(0)) // Ajusta seg�n tu entrada de ataque
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        // Activar el collider de golpe
        golpeCollider.SetActive(true);
    }

    // M�todo que se llamar� desde la animaci�n al finalizar el golpe
    public void FinGolpe()
    {
        // Desactivar el collider de golpe al finalizar el evento de la animaci�n
        golpeCollider.SetActive(false);
    }
}

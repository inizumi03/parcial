using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sombras : MonoBehaviour
{
    public Transform objetivo; // Referencia al objeto que se va a seguir
    public float velocidad = 5f; // Velocidad de seguimiento

    private void Update()
    {
        if (objetivo != null)
        {
            // Obtener la posici�n del objetivo en X y Z, pero mantener la posici�n actual en Y
            Vector3 posicionObjetivo = new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z);

            // Mover el objeto hacia la posici�n del objetivo
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
        }
    }
}

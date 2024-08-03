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
            // Obtener la posición del objetivo en X y Z, pero mantener la posición actual en Y
            Vector3 posicionObjetivo = new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z);

            // Mover el objeto hacia la posición del objetivo
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
        }
    }
}

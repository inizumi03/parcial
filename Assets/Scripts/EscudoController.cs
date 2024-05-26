using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoController : MonoBehaviour
{
    public GameObject prefabEscudo; // Prefab del escudo
    private GameObject instanciaEscudo; // Instancia del escudo

    void Update()
    {
        // Si se presiona la tecla 'E'
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Instanciar el escudo como hijo del jugador si aún no existe una instancia activa
            if (instanciaEscudo == null)
            {
                instanciaEscudo = Instantiate(prefabEscudo, transform.position, transform.rotation, transform);
            }
        }

        // Si se suelta la tecla 'E'
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Destruir la instancia del escudo si existe
            if (instanciaEscudo != null)
            {
                Destroy(instanciaEscudo);
                instanciaEscudo = null;
            }
        }
    }
}
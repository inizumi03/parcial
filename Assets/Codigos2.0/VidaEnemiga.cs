using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemiga : MonoBehaviour


{
    [SerializeField] private float vida = 100f; // Cantidad de vida inicial del enemigo

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;

        if (vida <= 0)
        {
            Destruir();
        }
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemiga : MonoBehaviour
{
    [SerializeField] private float vida = 100f;  // Cantidad de vida inicial del enemigo
    private float vidaMaxima;
    public Image barraSalud;  // Referencia a la barra de salud en el Canvas
    public Text textoVida;   // Referencia al texto de la vida en el Canvas

    private void Start()
    {
        vidaMaxima = vida; // Almacena la vida máxima al inicio
        ActualizarInterfaz(); // Asegúrate de que la interfaz se actualiza al inicio
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            vida = 0; // Asegúrate de que la vida no baje de 0
            Destruir();
        }
        ActualizarInterfaz(); // Actualiza la interfaz cada vez que recibe daño
    }

    public float GetVidaActual()
    {
        return vida;  // Devuelve la vida actual
    }

    public float GetVidaMaxima()
    {
        return vidaMaxima;  // Devuelve la vida máxima
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }

    private void ActualizarInterfaz()
    {
        if (barraSalud != null)
        {
            barraSalud.fillAmount = vida / vidaMaxima;  // Actualiza la barra de salud
        }

        if (textoVida != null)
        {
            textoVida.text = "Salud: " + vida.ToString("F0");  // Actualiza el texto de la vida
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaludJose : MonoBehaviour

{
    [SerializeField] private float vida = 100f;  // Cantidad de vida inicial del enemigo
    private float vidaMaxima;
    public Image barraSalud;  // Referencia a la barra de salud en el Canvas
    public Text textoVida;   // Referencia al texto de la vida en el Canvas
    public Animator animator;  // Referencia al Animator del enemigo

    private void Start()
    {
        vidaMaxima = vida; // Almacena la vida m�xima al inicio
        ActualizarInterfaz(); // Aseg�rate de que la interfaz se actualiza al inicio
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            vida = 0; // Aseg�rate de que la vida no baje de 0
            Muerte();
        }
        ActualizarInterfaz(); // Actualiza la interfaz cada vez que recibe da�o
    }

    private void Muerte()
    {
        // Activa el trigger de muerte en el Animator
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Desactiva el collider para evitar m�s interacciones
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Desactiva el Rigidbody para que el enemigo no siga movi�ndose
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Espera a que la animaci�n de muerte termine antes de destruir el objeto
        StartCoroutine(EsperarYDestruir());
    }

    private IEnumerator EsperarYDestruir()
    {
        // Espera a que la animaci�n de muerte termine antes de destruir el objeto
        yield return new WaitForSeconds(3f);  // Ajusta el tiempo seg�n la duraci�n de la animaci�n
        Destroy(gameObject);
    }

    public float GetVidaActual()
    {
        return vida;  // Devuelve la vida actual
    }

    public float GetVidaMaxima()
    {
        return vidaMaxima;  // Devuelve la vida m�xima
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





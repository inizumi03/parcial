using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class romperParedes : MonoBehaviour
{
    public GameObject DiscoInicio; // Punto de inicio de donde el disco saldrá
    public GameObject DiscoPrefab; // Prefab del disco
    public float DiscoVelocidad; // Velocidad del disco

    public int numDiscosDisparados = 0; // Contador de discos disparados
    public int maxDiscos = 3; // Número máximo de discos que puede disparar el jugador antes de detenerse
    public float intervaloDisparo = 2f; // Intervalo entre disparos

    private bool puedeDisparar = true; // Indica si el jugador puede disparar
    private WaitForSeconds esperaDisparo; // Tiempo de espera antes de permitir otro disparo

    void Start()
    {
        esperaDisparo = new WaitForSeconds(intervaloDisparo);
    }

    void Update()
    {
        if (puedeDisparar && Input.GetKeyDown(KeyCode.E) && numDiscosDisparados < maxDiscos)
        {
            Disparar();
            numDiscosDisparados++;

            if (numDiscosDisparados >= maxDiscos)
            {
                // Detener temporalmente los disparos
                StartCoroutine(EsperarDisparo());
            }
        }
    }

    void Disparar()
    {
        // Instanciar el DiscoPrefab en la posición de DiscoInicio
        GameObject DiscoTemporal = Instantiate(DiscoPrefab, DiscoInicio.transform.position, DiscoInicio.transform.rotation) as GameObject;

        // Obtener Rigidbody para agregar fuerza
        Rigidbody rb = DiscoTemporal.GetComponent<Rigidbody>();

        // Agregar la fuerza al disco
        rb.AddForce(DiscoInicio.transform.forward * DiscoVelocidad, ForceMode.Impulse);

        // Destruir el disco después de un tiempo
        Destroy(DiscoTemporal, 5.0f);
    }

    IEnumerator EsperarDisparo()
    {
        puedeDisparar = false;
        yield return esperaDisparo;
        numDiscosDisparados = 0;
        puedeDisparar = true;
    }
}

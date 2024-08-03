using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFollow2 : MonoBehaviour
{

    public float speed = 2f;
    public Transform jugador1;
    public Transform jugador2;
    public float distanciaDeteccion = 15f;
    public List<Transform> puntosDePatrullaje;
    public float distanciaAtaque = 2f;
    public float tiempoEntreAtaques = 1f;

    private Transform objetivoActual;
    private int puntoPatrullajeActual = 0;
    private bool persiguiendoJugador = false;
    private bool atacando = false;

    private enum Estado
    {
        Patrullando,
        Persiguiendo,
        Atacando
    }

    private Estado estadoActual = Estado.Patrullando;

    private void Update()
    {
        switch (estadoActual)
        {
            case Estado.Patrullando:
                Patrullar();
                DetectarJugador();
                break;
            case Estado.Persiguiendo:
                Perseguir();
                break;
            case Estado.Atacando:
                Atacar();
                break;
        }
    }

    private void Patrullar()
    {
        if (puntosDePatrullaje.Count == 0)
            return;

        Transform puntoDePatrullaje = puntosDePatrullaje[puntoPatrullajeActual];
        Vector3 direccion = (puntoDePatrullaje.position - transform.position).normalized;
        transform.position += direccion * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, puntoDePatrullaje.position) < 0.2f)
        {
            puntoPatrullajeActual = (puntoPatrullajeActual + 1) % puntosDePatrullaje.Count;
        }
    }

    private void DetectarJugador()
    {
        float distanciaAlJugador1 = Vector3.Distance(transform.position, jugador1.position);
        float distanciaAlJugador2 = Vector3.Distance(transform.position, jugador2.position);

        if (distanciaAlJugador1 < distanciaAlJugador2 && distanciaAlJugador1 < distanciaDeteccion)
        {
            objetivoActual = jugador1;
            persiguiendoJugador = true;
            estadoActual = Estado.Persiguiendo;
        }
        else if (distanciaAlJugador2 < distanciaAlJugador1 && distanciaAlJugador2 < distanciaDeteccion)
        {
            objetivoActual = jugador2;
            persiguiendoJugador = true;
            estadoActual = Estado.Persiguiendo;
        }
    }

    private void Perseguir()
    {
        if (objetivoActual == null)
        {
            persiguiendoJugador = false;
            estadoActual = Estado.Patrullando;
            return;
        }

        Vector3 direccion = (objetivoActual.position - transform.position).normalized;
        transform.position += direccion * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, objetivoActual.position) < distanciaAtaque)
        {
            estadoActual = Estado.Atacando;
        }

        if (Vector3.Distance(transform.position, objetivoActual.position) > distanciaDeteccion)
        {
            persiguiendoJugador = false;
            estadoActual = Estado.Patrullando;
        }
    }

    private void Atacar()
    {
        if (atacando)
            return;

        atacando = true;
        StartCoroutine(RealizarAtaque());
    }

    private IEnumerator RealizarAtaque()
    {
        Debug.Log("Atacando al jugador");
        yield return new WaitForSeconds(tiempoEntreAtaques);
        atacando = false;

        if (Vector3.Distance(transform.position, objetivoActual.position) > distanciaAtaque)
        {
            estadoActual = Estado.Persiguiendo;
        }
    }

}   

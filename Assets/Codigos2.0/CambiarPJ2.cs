using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPJ2 : MonoBehaviour

{
    public static MOVcrontrollerTony tonyController; // Referencia al controlador de Tony
    public static MovcrontrollerSun sunController;   // Referencia al controlador de Sun
    public static MonoBehaviour jugadorActivo;      // Referencia al jugador activo

    public GameObject tonyPrefab; // Prefab del personaje Tony
    public GameObject sunPrefab;  // Prefab del personaje Sun

    public GameObject seguidorTonyPrefab; // Prefab del seguidor de Tony
    public GameObject seguidorSunPrefab;  // Prefab del seguidor de Sun

    private static Vector3 posicionUltimoPJActivo;  // Variable global para la posición del personaje activo
    private static Vector3 ultimaPosicionSeguidorTony; // Última posición del seguidor de Tony
    private static Vector3 ultimaPosicionSeguidorSun;  // Última posición del seguidor de Sun

    private void Awake()
    {
        // Encuentra los personajes en la escena
        tonyController = tonyPrefab.GetComponent<MOVcrontrollerTony>();
        sunController = sunPrefab.GetComponent<MovcrontrollerSun>();

        // Inicialmente activa a Sun y desactiva a Tony
        sunController.gameObject.SetActive(true);
        tonyController.gameObject.SetActive(false);
        jugadorActivo = sunController;
        posicionUltimoPJActivo = sunController.transform.position;  // Guarda la posición inicial de Sun

        // Inicializa los seguidores
        if (seguidorTonyPrefab != null)
        {
            seguidorTonyPrefab.SetActive(false); // Desactiva el seguidor de Tony al inicio
        }
        if (seguidorSunPrefab != null)
        {
            seguidorSunPrefab.SetActive(false); // Desactiva el seguidor de Sun al inicio
        }

        // Configuración inicial
        Physics.gravity = new Vector3(0, -30, 0);
    }

    void Update()
    {
        // Cambia a Tony cuando se presiona la tecla 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarAtony();
        }

        // Cambia a Sun cuando se presiona la tecla 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarAsun();
        }
    }

    private void CambiarAtony()
    {
        if (jugadorActivo != tonyController)  // Verifica que el jugador activo no es Tony
        {
            sunController.gameObject.SetActive(false);  // Desactiva a Sun
            if (seguidorSunPrefab != null)
            {
                ultimaPosicionSeguidorSun = seguidorSunPrefab.transform.position; // Guarda la posición del seguidor de Sun
                seguidorSunPrefab.SetActive(false); // Desactiva el seguidor de Sun
            }

            // Guarda la posición de Sun antes de cambiar de personaje
            posicionUltimoPJActivo = sunController.transform.position;

            tonyController.gameObject.SetActive(true);  // Activa a Tony
            if (seguidorTonyPrefab != null)
            {
                StartCoroutine(ActivarSeguidorTony()); // Activa el seguidor de Tony con un pequeño retraso
            }

            // Restaura la posición de Tony al lugar donde estaba Sun
            tonyController.transform.position = posicionUltimoPJActivo;

            // Establece a Tony como el jugador activo
            jugadorActivo = tonyController;
        }
    }

    private void CambiarAsun()
    {
        if (jugadorActivo != sunController)  // Verifica que el jugador activo no es Sun
        {
            tonyController.gameObject.SetActive(false);  // Desactiva a Tony
            if (seguidorTonyPrefab != null)
            {
                ultimaPosicionSeguidorTony = seguidorTonyPrefab.transform.position; // Guarda la posición del seguidor de Tony
                seguidorTonyPrefab.SetActive(false); // Desactiva el seguidor de Tony
            }

            // Guarda la posición de Tony antes de cambiar de personaje
            posicionUltimoPJActivo = tonyController.transform.position;

            sunController.gameObject.SetActive(true);    // Activa a Sun
            if (seguidorSunPrefab != null)
            {
                StartCoroutine(ActivarSeguidorSun()); // Activa el seguidor de Sun con un pequeño retraso
            }

            // Restaura la posición de Sun al lugar donde estaba Tony
            sunController.transform.position = posicionUltimoPJActivo;

            // Establece a Sun como el jugador activo
            jugadorActivo = sunController;
        }
    }

    private IEnumerator ActivarSeguidorTony()
    {
        yield return new WaitForSeconds(0.1f); // Espera un pequeño retraso para evitar problemas de sincronización
        seguidorTonyPrefab.transform.position = ultimaPosicionSeguidorTony; // Restaura la posición del seguidor de Tony
        seguidorTonyPrefab.SetActive(true); // Activa el seguidor de Tony
    }

    private IEnumerator ActivarSeguidorSun()
    {
        yield return new WaitForSeconds(0.1f); // Espera un pequeño retraso para evitar problemas de sincronización
        seguidorSunPrefab.transform.position = ultimaPosicionSeguidorSun; // Restaura la posición del seguidor de Sun
        seguidorSunPrefab.SetActive(true); // Activa el seguidor de Sun
    }
}



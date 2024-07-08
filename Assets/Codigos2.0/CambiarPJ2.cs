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

        private static Vector3 posicionUltimoPJActivo;  // Variable global para la posición del personaje activo

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

                // Guarda la posición de Sun antes de cambiar de personaje
                posicionUltimoPJActivo = sunController.transform.position;

                tonyController.gameObject.SetActive(true);  // Activa a Tony

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

                // Guarda la posición de Tony antes de cambiar de personaje
                posicionUltimoPJActivo = tonyController.transform.position;

                sunController.gameObject.SetActive(true);    // Activa a Sun

                // Restaura la posición de Sun al lugar donde estaba Tony
                sunController.transform.position = posicionUltimoPJActivo;

                // Establece a Sun como el jugador activo
                jugadorActivo = sunController;
            }
        }
    }



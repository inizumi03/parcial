using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarFuerzaSalto : MonoBehaviour


{
    public float incrementoFuerzaSalto = 10f; // Cantidad de incremento en la fuerza de salto
    public float duracionIncremento = 10f;    // Duración del incremento en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica si el objeto que atraviesa el power-up es Tony
            MOVcrontrollerTony tony = other.GetComponent<MOVcrontrollerTony>();
            if (tony != null)
            {
                StartCoroutine(AumentarFuerzaSaltoTemporalmente(tony));
                Destroy(gameObject); // Destruye el objeto power-up
                return;
            }

            // Verifica si el objeto que atraviesa el power-up es Sun
            MovcrontrollerSun sun = other.GetComponent<MovcrontrollerSun>();
            if (sun != null)
            {
                StartCoroutine(AumentarFuerzaSaltoTemporalmente(sun));
                Destroy(gameObject); // Destruye el objeto power-up
                return;
            }
        }
    }

    private IEnumerator AumentarFuerzaSaltoTemporalmente(MOVcrontrollerTony tony)
    {
        tony.fuerzaSalto += incrementoFuerzaSalto; // Incrementa la fuerza de salto
        yield return new WaitForSeconds(duracionIncremento); // Espera 10 segundos
        tony.fuerzaSalto -= incrementoFuerzaSalto; // Restaura la fuerza de salto original
    }

    private IEnumerator AumentarFuerzaSaltoTemporalmente(MovcrontrollerSun sun)
    {
        sun.fuerzaSalto += incrementoFuerzaSalto; // Incrementa la fuerza de salto
        yield return new WaitForSeconds(duracionIncremento); // Espera 10 segundos
        sun.fuerzaSalto -= incrementoFuerzaSalto; // Restaura la fuerza de salto original
    }
}









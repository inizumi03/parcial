using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchosCollisionHandler : MonoBehaviour


    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pared"))
            {
                Destroy(other.gameObject); // Destruir el objeto con la etiqueta "Pared"
            }
        }

        public void Initialize()
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                // Destruir el prefab después de que termine su animación
                Destroy(transform.parent.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
            }
            else
            {
                // Destruir el prefab después de un tiempo de espera predeterminado
                Destroy(transform.parent.gameObject, 5f); // Destruir el prefab después de 5 segundos como precaución
            }
        }
    }





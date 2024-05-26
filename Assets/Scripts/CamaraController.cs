using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour


{
    public Transform[] targets; // Referencias a los transform de los dos objetivos que la c�mara puede seguir
    public Vector3 offset; // Desplazamiento de la c�mara respecto al objetivo actual
    private int currentTargetIndex = 0; // �ndice del objetivo actual que sigue la c�mara

    void Start()
    {
        // Ajustar el offset inicial si no lo has hecho en el Inspector
        if (offset == Vector3.zero)
        {
            offset = transform.position - targets[currentTargetIndex].position;
        }
    }

    void LateUpdate()
    {
        // Verificar si se presiona la tecla Tab para cambiar el objetivo actual
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Cambiar al siguiente objetivo
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }

        // Obtener el transform del objetivo actual
        Transform currentTarget = targets[currentTargetIndex];

        // Actualizar la posici�n de la c�mara para seguir al objetivo actual con el desplazamiento offset
        transform.position = currentTarget.position + offset;
    }
}


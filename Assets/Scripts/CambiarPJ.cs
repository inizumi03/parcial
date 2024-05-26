using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPJ : MonoBehaviour

{
    public static bool gameOver = false;
    public static bool winCondition = false;
    public static int actualPlayer = 0;
    public static MOVcrontroller jugadorActivo; // Referencia al jugador activo
    public List<MOVcrontroller> players;

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
        gameOver = false;
        winCondition = false;
        SetActivePlayer(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            actualPlayer = (actualPlayer + 1) % players.Count;
            SetActivePlayer(actualPlayer);
        }
    }

    private void SetActivePlayer(int index)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].enabled = (i == index); // Activar el componente MOVcrontroller solo para el jugador actual
            players[i].GetComponent<Rigidbody>().constraints = (i == index) ? RigidbodyConstraints.FreezeRotation : RigidbodyConstraints.FreezeAll; // Congelar la posición y la rotación para el jugador actual
            if (i==index)
            {
                jugadorActivo = players[i]; // Actualizar la referencia al jugador activo
            }
        }
    }
}

   




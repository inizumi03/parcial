using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public delegate void PuertaEventHandler();
    public static event PuertaEventHandler OnPuertaEnter;

    public static void PuertaTrigger()
    {
        if (OnPuertaEnter != null)
        {
            OnPuertaEnter();
        }
    }

    private void OnEnable()
    {
        OnPuertaEnter += CambiarEscena;
    }

    private void OnDisable()
    {
        OnPuertaEnter -= CambiarEscena;
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene("PlataformerScene");
    }
}



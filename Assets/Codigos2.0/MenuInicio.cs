using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void Tutorial(string NombreTutorial)
    {
        SceneManager.LoadScene(NombreTutorial);
    }
    public void Comenzar(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
    public void Salir() 
    {

        Application.Quit();

    }
}

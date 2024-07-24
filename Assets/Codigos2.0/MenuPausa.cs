using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public bool Pausa = false;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
               menuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

               
            }
        }
    }

    public void Resumir()
    {
       menuPausa.SetActive(false);
        Pausa = false ;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void IrAlMenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu); 
    }
}

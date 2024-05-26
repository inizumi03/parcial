using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salud : MonoBehaviour
{
    public float Vida = 100;
    public float vidaMax = 100;
    public Image BarraSalud;
    public Text TextoVida;
    public GameObject Derrota;

    void Update()
    {
        ActualizarInterfaz();
    }
    public void RecivirDaño(float daño)
    {
        Vida -= daño;
        if(Vida<=0)
        {
            Instantiate(Derrota);
            Destroy(gameObject);
        }
    }
   
    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Vida/vidaMax;
        TextoVida.text = "Salud" + Vida.ToString("F0");
    }
}

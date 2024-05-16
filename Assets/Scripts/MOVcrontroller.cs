using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//getcomponen nombre del codigo 
// trasform.parent.getcompen nombre del archivo  
//transform.parent.Find("").getcomponen 
//public Disparar componente disparo  
public class MOVcrontroller : MonoBehaviour
{
    public float fuerzaSalto = 7f;
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    private int saltos = 0;
    private Rigidbody rb;
    private Animator animator;
    private bool isFacingRight = true; // Variable para rastrear la dirección en la que mira el personaje

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Saltar();
        Mover();
        
    }

    void Update()
    {
        DetectarSentido();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            saltos = 0; 
        }
    }

    private void Mover()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            animator.Play("luna run 3_0");
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(+moveSpeed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,-moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, +moveSpeed);
        }
    }

    private void Saltar() 
    {
        if (saltos < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                saltos++;
            }
        }
    }

    private void DetectarSentido()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized * moveSpeed;

        // Actualizar la animación
        if (movement.magnitude > 0)
        {
            // Si hay movimiento, activar la animación de caminar
            animator.SetBool("SeMueve", true);

            // Cambiar la dirección del sprite según la entrada de movimiento
            if (moveHorizontal < 0 && isFacingRight)
            {
                Flip();
            }
            else if (moveHorizontal > 0 && !isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            // Si no hay movimiento, activar la animación de estar quieto
            animator.SetBool("SeMueve", false);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Cambiar el estado de la dirección del personaje
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Invertir la escala en el eje X
        transform.localScale = scale;
    }
}





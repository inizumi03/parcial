using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovcrontrollerSun : MonoBehaviour

{
    public float fuerzaSalto = 7f;
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float gravedadExtra = 10f; // Aumento de la gravedad
    private bool puedeSaltar = true;
    public Rigidbody rb;
    private Animator animator;
    private bool isFacingRight = true; // Variable para rastrear la direcci�n en la que mira el personaje
    private bool isActive = true; // Por defecto, el personaje est� activo
    public AtaqueSun ataqueSun; // Referencia al script AtaqueSun

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Obtener el Animator directamente
        ataqueSun = GetComponent<AtaqueSun>(); // Obtener el AtaqueSun directamente
        Saltar();
    }

    private void FixedUpdate()
    {
        if (isActive) // Solo actualizar el movimiento si el personaje est� activo
        {
            Mover();
            AplicarGravedadExtra();
        }
    }

    void Update()
    {
        if (isActive) // Solo actualizar la l�gica de salto si el personaje est� activo
        {
            DetectarSentido();
            Saltar();

            if (Input.GetMouseButtonDown(0)) // Si se presiona el bot�n izquierdo del rat�n
            {
                Atacar();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;
        if (collision.gameObject.tag == "Floor")
        {
            puedeSaltar = true;
            animator.SetBool("isGrounded", true);
            animator.SetBool("isFalling", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("isGrounded", false);
        }
    }

    private void Mover()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward;
        }

        moveDirection = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        ActualizarAnimacion(moveDirection);
    }

    private void Saltar()
    {
        if (puedeSaltar && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            puedeSaltar = false;
            animator.SetTrigger("Jump");
            animator.SetBool("isFalling", true);
        }
    }

    private void DetectarSentido()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f).normalized * moveSpeed;

        // Cambiar la direcci�n del sprite seg�n la entrada de movimiento
        if (moveHorizontal < 0 && isFacingRight)
        {
            Flip();
        }
        else if (moveHorizontal > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    private void ActualizarAnimacion(Vector3 moveDirection)
    {
        animator.SetBool("SeMueve", moveDirection.magnitude > 0);
    }

    private void Atacar()
    {
        animator.SetTrigger("Atacar"); // Activar la transici�n de ataque con un trigger
    }

    private void AplicarGravedadExtra()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (gravedadExtra - 1) * Time.fixedDeltaTime;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Cambiar el estado de la direcci�n del personaje
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Invertir la escala en el eje X
        transform.localScale = scale;
    }

    public void SetActive(bool active)
    {
        isActive = active;

        // Desactivar el componente Rigidbody cuando el personaje no est� activo
        rb.isKinematic = !active;

        // Desactivar el componente Animator cuando el personaje no est� activo
        animator.enabled = active;
    }

    // Esta funci�n se llamar� desde el evento de animaci�n
    public void DispararAquaSun()
    {
        if (ataqueSun != null)
        {
            ataqueSun.Disparar();
        }
    }
}









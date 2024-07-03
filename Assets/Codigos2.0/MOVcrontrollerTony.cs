using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVcrontrollerTony : MonoBehaviour
{
    public float fuerzaSalto = 7f;
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float gravedadExtra = 10f; // Aumento de la gravedad
    private bool puedeSaltar = true;
    public Rigidbody rb;
    private Animator animator;
    private bool isFacingRight = true; // Variable para rastrear la dirección en la que mira el personaje
    private bool isActive = true; // Por defecto, el personaje está activo
    private UltiController ultiController; // Referencia al UltiController

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = transform.Find("TonySprite").GetComponent<Animator>(); // Encuentra el Animator en el sprite hijo
        ultiController = GetComponent<UltiController>(); // Obtener el componente UltiController
        Saltar();
    }

    private void FixedUpdate()
    {
        Mover();
        AplicarGravedadExtra();
    }

    void Update()
    {
        DetectarSentido();
        Saltar();

        if (Input.GetMouseButtonDown(0)) // Si se presiona el botón izquierdo del ratón
        {
            Atacar();
        }

        if (Input.GetMouseButtonDown(1)) // Si se presiona el botón derecho del ratón
        {
            Ulti();
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

        if (collision.gameObject.tag == "Puerta")
        {
            EventManager.PuertaTrigger();
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

    private void ActualizarAnimacion(Vector3 moveDirection)
    {
        animator.SetBool("SeMueve", moveDirection.magnitude > 0);
    }

    private void Atacar()
    {
        animator.SetTrigger("Atacar"); // Activar la transición de ataque con un trigger
    }

    private void Ulti()
    {
        animator.SetTrigger("Ulti"); // Activar la transición de ulti con un trigger
        if (ultiController != null)
        {
            ultiController.ActivarUlti(); // Llamar al método ActivarUlti del UltiController
        }
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
        isFacingRight = !isFacingRight; // Cambiar el estado de la dirección del personaje
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Invertir la escala en el eje X
        transform.localScale = scale;
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }
}






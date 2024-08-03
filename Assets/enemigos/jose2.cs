using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jose2 : MonoBehaviour

{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public bool atacando;
    public GameObject target;

    public float walkSpeed = 1f;
    public float runSpeed = 2f;
    public float detectionRange = 10f; // Rango de detección del enemigo
    public float attackRange = 1f; // Rango de ataque del enemigo
    public float attackDuration = 1f; // Duración de la animación de ataque

    private Rigidbody rb;
    private Vector3 targetPosition;
    private float attackTimer;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Comportamiento_Enemigo()
    {
        if (target == null || Vector3.Distance(transform.position, target.transform.position) > detectionRange)
        {
            ani.SetBool("run", false);

            cronometro += Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    rb.MovePosition(transform.position + transform.forward * walkSpeed * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackRange && !atacando)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                rb.MovePosition(transform.position + transform.forward * runSpeed * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else if (!atacando)
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                atacando = true;
                attackTimer = attackDuration; // Inicia el temporizador de ataque
            }
        }
    }

    private void Update()
    {
        // Actualiza el temporizador de ataque si el enemigo está atacando
        if (atacando)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                ani.SetBool("attack", false);
                atacando = false;
            }
        }

        // Detectar al jugador en cada Update
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                target = hitCollider.gameObject;
                break;
            }
        }

        Comportamiento_Enemigo();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}



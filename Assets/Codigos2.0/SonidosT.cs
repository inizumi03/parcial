using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosT : MonoBehaviour

{
    private Animator animator;
    private AudioSource audioSource;

    public AudioClip golpe1Sound; // Sonido para el evento "Golpe1"
    public AudioClip ultiSound; // Sonido para el evento "Ulti"

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Método llamado por la animación en el evento "Golpe1"
    public void Golpe1Sound()
    {
        ReproducirSonido(golpe1Sound);
    }

    // Método llamado por la animación en el evento "Ulti"
    public void UltiSound()
    {
        ReproducirSonido(ultiSound);
    }

    private void ReproducirSonido(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Reproducir el sonido una sola vez
        }
    }
}







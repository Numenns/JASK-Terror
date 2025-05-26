using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    private bool yaActivado = false;

    public GameObject objetoAActivar;

    [Header("Audio")]
    public AudioClip sonidoActivacion; // Clip de sonido asignable desde el Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Asegúrate de tener un AudioSource en este objeto
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay AudioSource, añade uno
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void ActivarObjeto()
    {
        if (!yaActivado)
        {
            yaActivado = true;

            Inventario.Instancia.Motores += 1;

            gameObject.tag = "Untagged";

            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }

            if (sonidoActivacion != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoActivacion);
            }
        }
    }
}

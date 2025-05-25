using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor.Experimental.GraphView;

public class DeteccionFuego : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas canvasAdvertencia;
    public float tiempoRequeridoEnFuego = 5f;
    private float tiempoEnFuego = 0f;
    private bool enFuego = false;

    public RayRecolectables recolector; 

    void Start()
    {
        if (canvasAdvertencia != null)
            canvasAdvertencia.enabled = false;
    }

    void Update()
    {
        if (enFuego)
        {
            tiempoEnFuego += Time.deltaTime;

            if (tiempoEnFuego >= tiempoRequeridoEnFuego && canvasAdvertencia != null)
            {
                canvasAdvertencia.enabled = true;
            }
        }

    
        if (recolector != null && recolector.GetContador() >= 5)
        {
            SceneManager.LoadScene("EscenaSilva");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuego"))
        {
            enFuego = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fuego"))
        {
            enFuego = false;
            tiempoEnFuego = 0f;
            if (canvasAdvertencia != null)
                canvasAdvertencia.enabled = false;
        }
    }
}


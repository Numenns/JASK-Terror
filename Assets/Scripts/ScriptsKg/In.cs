using System.Collections;
using UnityEngine;

/// <summary>
/// Controla la pantalla de introducción al iniciar el juego y la activación del temporizador.
/// </summary>
public class In : MonoBehaviour
{
    /// <summary>
    /// Referencia al Canvas que contiene la introducción (pantalla inicial).
    /// </summary>
    public GameObject introCanvas;

    /// <summary>
    /// Referencia al script que controla el temporizador del juego.
    /// </summary>
    public Timeerr temporizadorScript;

    /// <summary>
    /// Duración (en segundos) durante la cual se muestra la introducción.
    /// </summary>
    public float duracionIntro = 5f;

    /// <summary>
    /// Se ejecuta al iniciar el juego. Comienza la corrutina que controla la introducción.
    /// </summary>
    void Start()
    {
        StartCoroutine(IniciarJuegoConIntro());
    }

    /// <summary>
    /// Corrutina que muestra la introducción durante un tiempo determinado,
    /// desactiva el temporizador mientras tanto y lo activa al finalizar.
    /// </summary>
    /// <returns>Retorna un IEnumerator para el sistema de corrutinas de Unity.</returns>
    IEnumerator IniciarJuegoConIntro()
    {
        
        introCanvas.SetActive(true);

        temporizadorScript.DesactivarTemporizador();

       
        yield return new WaitForSeconds(duracionIntro);

       
        introCanvas.SetActive(false);
        temporizadorScript.ActivarTemporizador();
    }
}
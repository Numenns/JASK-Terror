using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Controla la activación de una cinemática al entrar un objeto con el tag "Player" en el trigger.
/// </summary>
public class cinematicaFinal : MonoBehaviour
{
    /// <summary>
    /// Componente PlayableDirector que controla la reproducción de la cinemática.
    /// </summary>
    public PlayableDirector director;

    /// <summary>
    /// Objeto que representa al personaje en la escena.
    /// </summary>
    public GameObject personaje;

    /// <summary>
    /// Objeto que representa al enemigo en la escena.
    /// </summary>
    public GameObject enemigo;

    /// <summary>
    /// Cámara principal de la escena.
    /// </summary>
    public GameObject mainCamera;

    /// <summary>
    /// Método que se ejecuta cuando un objeto entra en el trigger.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (personaje != null)
                personaje.SetActive(false);
            enemigo.SetActive(false);
            mainCamera.SetActive(false);

            director.Play();
        }
    }
}
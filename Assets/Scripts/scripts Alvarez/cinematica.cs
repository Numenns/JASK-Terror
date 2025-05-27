using UnityEngine;

sing UnityEngine;

/// <summary>
/// Controla la transición entre la cámara cinemática y el control del jugador.
/// </summary>
public class cinematica : MonoBehaviour
{
    /// <summary>
    /// Cámara utilizada para la secuencia cinemática.
    /// </summary>
    public GameObject camaraCinematica;

    /// <summary>
    /// Cámara asociada al jugador.
    /// </summary>
    public GameObject camaraJugador;

    /// <summary>
    /// Objeto que controla el movimiento o comportamiento del jugador.
    /// </summary>
    public GameObject controladorJugador;

    /// <summary>
    /// Activa la cámara y el controlador del jugador, desactivando la cámara cinemática.
    /// </summary>
    public void ActivarJugador()
    {
        camaraCinematica.SetActive(false);
        camaraJugador.SetActive(true);
        controladorJugador.SetActive(true);
    }
}
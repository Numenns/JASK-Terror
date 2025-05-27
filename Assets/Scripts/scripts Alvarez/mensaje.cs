using UnityEngine;

/// <summary>
/// Controla la activación y desactivación de un panel de mensaje cuando el jugador entra o sale de un trigger.
/// </summary>
public class mensaje : MonoBehaviour
{
    /// <summary>
    /// Panel de mensaje que se muestra u oculta al interactuar con el trigger.
    /// </summary>
    public GameObject panelMensaje;

    /// <summary>
    /// Inicializa el panel de mensaje como desactivado al comenzar.
    /// </summary>
    void Start()
    {
        panelMensaje.SetActive(false);
    }

    /// <summary>
    /// Activa el panel de mensaje cuando el jugador entra en el trigger.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensaje.SetActive(true);
        }
    }

    /// <summary>
    /// Desactiva el panel de mensaje cuando el jugador sale del trigger.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensaje.SetActive(false);
        }
    }
}
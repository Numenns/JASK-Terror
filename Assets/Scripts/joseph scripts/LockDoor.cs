using UnityEngine;

/// <summary>
/// Controla una puerta bloqueada que se destruye cuando el jugador ha recogido la linterna.
/// Muestra un mensaje cuando el jugador se acerca a la puerta.
/// </summary>
public class LockDoor : MonoBehaviour
{
    /// <summary>
    /// Mensaje que se muestra al jugador cuando se acerca a la puerta bloqueada.
    /// </summary>
    public GameObject lockdoorMessage;

    /// <summary>
    /// Referencia al controlador de la linterna para verificar si el jugador la ha recogido.
    /// </summary>
    public lightControl lightController;

    /// <summary>
    /// Inicializa la referencia al controlador de la linterna si no está asignada.
    /// </summary>
    private void Start()
    {
        if (lightController == null)
        {
            lightController = FindObjectOfType<lightControl>();
        }
    }

    /// <summary>
    /// Verifica en cada fotograma si el jugador ha recogido la linterna.
    /// Si es así, destruye la puerta bloqueada.
    /// </summary>
    private void Update()
    {
        if (lightController != null && lightController.linterapick)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Muestra el mensaje al jugador cuando entra en el área de activación de la puerta.
    /// </summary>
    /// <param name="other">El collider que entra en el área de activación.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lockdoorMessage != null)
                lockdoorMessage.SetActive(true);
        }
    }

    /// <summary>
    /// Oculta el mensaje cuando el jugador sale del área de activación de la puerta.
    /// </summary>
    /// <param name="other">El collider que sale del área de activación.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lockdoorMessage != null)
                lockdoorMessage.SetActive(false);
        }
    }
}

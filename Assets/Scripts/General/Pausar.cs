using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Gestiona la funcionalidad de pausa en el juego, alternando entre el estado de pausa y reanudación.
/// Controla la visibilidad de los paneles de pausa y audio, el cursor y el movimiento del jugador.
/// </summary>
public class Pausar : MonoBehaviour
{
    /// <summary>
    /// Panel de la interfaz de usuario que se muestra cuando el juego está en pausa.
    /// </summary>
    public GameObject panelPausa;

    /// <summary>
    /// Panel de la interfaz de usuario para ajustes de audio idios relacionados con el audio.
    /// </summary>
    public GameObject panelAudio;

    /// <summary>
    /// Indica si el juego está actualmente pausado.
    /// </summary>
    private bool pausado = false;

    /// <summary>
    /// Tecla utilizada para activar o desactivar la pausa.
    /// </summary>
    private KeyCode teclaPausa = KeyCode.Escape;

    /// <summary>
    /// Objeto que contiene el componente de movimiento del jugador.
    /// </summary>
    public GameObject Movement;

    /// <summary>
    /// Inicializa el estado del cursor al comenzar el juego, bloqueándolo en el centro de la pantalla.
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Verifica si se presiona la tecla de pausa para alternar el estado de pausa del juego.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(teclaPausa))
        {
            Pausa();
        }
    }

    /// <summary>
    /// Alterna el estado de pausa del juego, ajustando el tiempo, los paneles de UI, el cursor y el movimiento del jugador.
    /// Si el juego está pausado, reanuda el juego; si no, pausa el juego.
    /// </summary>
    public void Pausa()
    {
        if (pausado)
        {
            Time.timeScale = 1;
            panelPausa.SetActive(false);
            panelAudio.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Movement.GetComponent<Movement>().enabled = true;
            pausado = false;
        }
        else
        {
            Time.timeScale = 0;
            panelPausa.SetActive(true);
            panelAudio.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.GetComponent<Movement>().enabled = false;
            pausado = true;
        }
    }
}
using UnityEngine;

/// <summary>
/// Gestiona la navegación entre paneles de la interfaz de usuario del menú principal del juego.
/// Controla la activación y desactivación de los paneles de jugar, opciones y general, además de la salida del juego.
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Panel de la interfaz de usuario correspondiente a la sección "Jugar".
    /// </summary>
    public GameObject panelJugar;

    /// <summary>
    /// Panel de la interfaz de usuario correspondiente a la sección "Opciones".
    /// </summary>
    public GameObject panelOpciones;

    /// <summary>
    /// Panel de la interfaz de usuario correspondiente al menú general.
    /// </summary>
    public GameObject panelGeneral;

    /// <summary>
    /// Activa el panel de "Jugar" y desactiva los paneles de opciones y general.
    /// </summary>
    public void AbrirPanelJugar()
    {
        panelJugar.SetActive(true);
        panelOpciones.SetActive(false);
        panelGeneral.SetActive(false);
    }

    /// <summary>
    /// Activa el panel de "Opciones" y desactiva los paneles de jugar y general.
    /// </summary>
    public void AbrirPanelOpciones()
    {
        panelJugar.SetActive(false);
        panelGeneral.SetActive(false);
        panelOpciones.SetActive(true);
    }

    /// <summary>
    /// Activa el panel general y desactiva los paneles de jugar y opciones, volviendo al menú principal.
    /// </summary>
    public void volver()
    {
        panelJugar.SetActive(false);
        panelOpciones.SetActive(false);
        panelGeneral.SetActive(true);
    }

    /// <summary>
    /// Cierra la aplicación del juego y registra la acción en la consola de depuración.
    /// </summary>
    public void salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}
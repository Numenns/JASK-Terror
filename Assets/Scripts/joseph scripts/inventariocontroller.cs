using UnityEngine;
using TMPro;

/// <summary>
/// Gestiona la visualización de notas del jugador en la interfaz de usuario.
/// Permite mostrar u ocultar un panel de notas y actualizar su contenido basado en el inventario del jugador.
/// </summary>
public class MostrarNotasUI : MonoBehaviour
{
    /// <summary>
    /// Referencia al componente TextMeshProUGUI que muestra las notas.
    /// </summary>
    public TextMeshProUGUI textoNotas;

    /// <summary>
    /// Referencia al GameObject que actúa como contenedor del panel de notas.
    /// </summary>
    public GameObject canvasNotas;

    /// <summary>
    /// Inicializa el estado del panel de notas al inicio del juego.
    /// </summary>
    private void Start()
    {
        if (canvasNotas != null)
        {
            canvasNotas.SetActive(false);
        }
    }

    /// <summary>
    /// Detecta la pulsación de la tecla 'I' para alternar la visibilidad del panel de notas.
    /// Si se muestra el panel, actualiza su contenido con las notas actuales del inventario.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canvasNotas != null)
            {
                bool nuevoEstado = !canvasNotas.activeSelf;
                canvasNotas.SetActive(nuevoEstado);

                if (nuevoEstado)
                {
                    MostrarNotas();
                }
            }
        }
    }

    /// <summary>
    /// Actualiza el texto del panel de notas con las notas almacenadas en el inventario del jugador.
    /// </summary>
    public void MostrarNotas()
    {
        if (Inventario.Instancia == null || textoNotas == null) return;

        string resultado = "";

        foreach (string nota in Inventario.Instancia.notasGuardadas)
        {
            resultado += "• " + nota + "\n";
        }

        textoNotas.text = resultado;
    }
}

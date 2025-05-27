using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestiona la carga de una escena específica en el juego utilizando el nombre de la escena proporcionado.
/// </summary>
public class SigEscena : MonoBehaviour
{
    /// <summary>
    /// Nombre de la escena que se cargará.
    /// </summary>
    public string nombreEscena;

    /// <summary>
    /// Carga la escena especificada por el nombre almacenado en la variable nombreEscena.
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
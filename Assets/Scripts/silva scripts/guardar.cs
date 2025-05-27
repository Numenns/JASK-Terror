using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Clase para manejar las operaciones de guardado, carga de datos y navegación en la escena.
/// También muestra los datos almacenados en un TextMeshProUGUI.
/// </summary>
public class guardar : MonoBehaviour
{
    /// <summary>
    /// Campo de entrada de texto para capturar el nombre del jugador.
    /// </summary>
    public TMP_InputField nombre;
    /// <summary>
    /// Campo de texto para mostrar datos almacenados (usando TextMeshProUGUI).
    /// </summary>
    public TextMeshProUGUI textoDatos;
    /// <summary>
    /// Inicializa el estado del cursor como libre al inicio de la escena.
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    /// <summary>
    /// Guarda el nombre del jugador en la instancia del inventario.
    /// </summary>
    public void guardarN()
    {
        Debug.Log(Inventario.Instancia.TiempoActual);
        Inventario.Instancia.Nombre = nombre.text;
    }
    /// <summary>
    /// Llama al método para guardar los datos del inventario.
    /// </summary>
    public void guardarDatos()
    {
        Inventario.Instancia.GuardarDatos();
    }
    /// <summary>
    /// Llama al método para cargar los datos almacenados del inventario.
    /// </summary>
    public void cargar()
    {
        Inventario.Instancia.CargarDatos();
    }
    /// <summary>
    /// Carga la escena principal del menú.
    /// </summary>
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
    /// <summary>
    /// Muestra en el texto de la interfaz los datos almacenados en la lista del inventario.
    /// Si no hay datos, muestra un mensaje predeterminado.
    /// </summary>
    public void MostrarListaDeDatos()
    {
        if (Inventario.Instancia != null && Inventario.Instancia.datosCargados != null)
        {
            string textoFinal = "";

            foreach (var data in Inventario.Instancia.datosCargados)
            {
                textoFinal += $"Nombre: {data.nombre} | ";
                textoFinal += $"Tiempo: {data.temp} |  ";
                textoFinal += $"Notas: {data.Notas} \n";
                textoFinal += "------------------------\n";
            }

            textoDatos.text = textoFinal;
        }
        else
        {
            textoDatos.text = "No hay datos para mostrar.";
        }
    }
}

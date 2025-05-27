using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class guardar : MonoBehaviour
{
    public TMP_InputField nombre;
    public TextMeshProUGUI textoDatos;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void guardarN()
    {
        Debug.Log(Inventario.Instancia.TiempoActual);
        Inventario.Instancia.Nombre = nombre.text;
    }
    public void guardarDatos()
    {
        Inventario.Instancia.GuardarDatos();
    }
    public void cargar()
    {
        Inventario.Instancia.CargarDatos();
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
    public void MostrarListaDeDatos()
    {
        if (Inventario.Instancia != null && Inventario.Instancia.datosCargados != null)
        {
            string textoFinal = "";

            foreach (var data in Inventario.Instancia.datosCargados)
            {
                textoFinal += $"Nombre: {data.nombre} |";
                textoFinal += $"Tiempo: {data.temp} |";
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

using UnityEngine;
using UnityEngine.UI;

public class guardar : MonoBehaviour
{
    private InputField nombre;
    public void guardarN()
    {
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
}

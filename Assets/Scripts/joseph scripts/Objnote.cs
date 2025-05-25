using UnityEngine;

public class ObjNote : MonoBehaviour
{
    [Header("Mensaje mostrado al mirar el objeto")]
    public GameObject mensajeUI;

    [Header("Texto que se guarda al recoger")]
    [TextArea]
    public string textoNota;

    private bool recogido = false;

    public bool EstaDisponible()
    {
        return !recogido && gameObject.activeInHierarchy;
    }

    public void MostrarMensaje()
    {
        if (EstaDisponible() && mensajeUI != null)
        {
            mensajeUI.SetActive(true);
        }
    }

    public void OcultarMensaje()
    {
        if (mensajeUI != null)
        {
            mensajeUI.SetActive(false);
        }
    }

    public void ActivarObjeto()
    {
        if (EstaDisponible())
        {
            recogido = true;

            // Mostrar en consola el texto que se va a añadir
            Debug.Log("Texto a añadir al inventario: " + textoNota);

            // Agregar texto al inventario y mostrar confirmación en consola
            if (Inventario.Instancia != null)
            {
                Inventario.Instancia.AgregarNota(textoNota);
                Debug.Log("Se agregó al inventario: " + textoNota);
            }

            OcultarMensaje();
            gameObject.SetActive(false);
        }
    }
}

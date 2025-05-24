using UnityEngine;

public class ObjNote : MonoBehaviour
{
    [Header("Mensaje mostrado al mirar el objeto")]
    public GameObject mensajeUI;

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
            OcultarMensaje();
            gameObject.SetActive(false);
        }
    }
}

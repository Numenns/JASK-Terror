using UnityEngine;

public class cinematica : MonoBehaviour
{
    public GameObject camaraCinematica;
    public GameObject camaraJugador;
    public GameObject controladorJugador;


    public void ActivarJugador()
    {
        camaraCinematica.SetActive(false);
        camaraJugador.SetActive(true);
        controladorJugador.SetActive(true);
    }
}

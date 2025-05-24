using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject panelJugar;
    public GameObject panelOpciones;
    public GameObject panelGeneral;

    public void AbrirPanelJugar()
    {
        panelJugar.SetActive(true);
        panelOpciones.SetActive(false);
        panelGeneral.SetActive(false);
    }

    public void AbrirPanelOpciones()
    {
        panelJugar.SetActive(false);
        panelGeneral.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void volver()
    {
        panelJugar.SetActive(false);
        panelOpciones.SetActive(false);
        panelGeneral.SetActive(true);
    }

    public void salir()
    {   Application.Quit();
        Debug.Log("Salir del juego");
    }
}
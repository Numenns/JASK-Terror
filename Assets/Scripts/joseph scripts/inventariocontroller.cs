using UnityEngine;
using TMPro;

public class MostrarNotasUI : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textoNotas; // Asignar en el Inspector
    public GameObject canvasNotas;     // El Canvas que se mostrará/ocultará

    void Start()
    {
        if (canvasNotas != null)
        {
            canvasNotas.SetActive(false); // Asegura que esté desactivado al iniciar
        }
    }

    void Update()
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

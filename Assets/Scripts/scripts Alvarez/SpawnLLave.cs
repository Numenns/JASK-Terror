using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Gestiona la asignación y activación de una llave en una caja interactuable seleccionada aleatoriamente.
/// </summary>
public class SpawnLLave : MonoBehaviour
{
    /// <summary>
    /// Lista de objetos interactuables donde la llave puede aparecer.
    /// </summary>
    public List<GameObject> lugaresInteractuables;

    /// <summary>
    /// Objeto que representa la llave a activar.
    /// </summary>
    public GameObject llave;

    /// <summary>
    /// Objeto seleccionado aleatoriamente como la caja correcta que contiene la llave.
    /// </summary>
    public GameObject cajaCorrecta;

    /// <summary>
    /// Inicializa la selección de la caja correcta y desactiva la llave al comenzar.
    /// </summary>
    private void Start()
    {
        if (lugaresInteractuables.Count > 0)
        {
            int indice = Random.Range(0, lugaresInteractuables.Count);
            cajaCorrecta = lugaresInteractuables[indice];
            Debug.Log("Caja correcta asignada: " + cajaCorrecta.name);
        }

        if (llave != null)
            llave.SetActive(false);
    }

    /// <summary>
    /// Activa la llave si la caja usada coincide con la caja correcta.
    /// </summary>
    public void UsarLugar(GameObject caja)
    {
        Debug.Log("Caja usada: " + caja.name);
        Debug.Log("Caja correcta: " + cajaCorrecta.name);

        // Comparar por nombre en lugar de referencia exacta
        if (caja.name == cajaCorrecta.name && llave != null)
        {
            llave.SetActive(true);
            Debug.Log("caja correcta");
        }
        else
        {
            Debug.Log("No es la caja correcta");
        }
    }
}
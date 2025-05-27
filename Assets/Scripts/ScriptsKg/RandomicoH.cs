using UnityEngine;

/// <summary>
/// Activa aleatoriamente uno de los tres objetos de hojas al iniciar la escena.
/// Solo una hoja estará activa dependiendo del número generado aleatoriamente.
/// </summary>
public class RandomicoH : MonoBehaviour
{
    /// <summary>
    /// Objeto de hoja opción 1.
    /// </summary>
    public GameObject HojasB1;

    /// <summary>
    /// Objeto de hoja opción 2.
    /// </summary>
    public GameObject HojasB2;

    /// <summary>
    /// Objeto de hoja opción 3.
    /// </summary>
    public GameObject HojasB3;

    /// <summary>
    /// Valor aleatorio entre 1 y 3 que define qué hoja se activará.
    /// </summary>
    private int resultado;

    /// <summary>
    /// Se ejecuta al iniciar el juego. Genera un número aleatorio y activa la hoja correspondiente.
    /// </summary>
    void Start()
    {
        resultado = Random.Range(1, 4); 

        if (resultado == 1)
        {
            HojasB1.SetActive(true);
        }
        else if (resultado == 2)
        {
            HojasB2.SetActive(true);
        }
        else if (resultado == 3)
        {
            HojasB3.SetActive(true);
        }
    }
}

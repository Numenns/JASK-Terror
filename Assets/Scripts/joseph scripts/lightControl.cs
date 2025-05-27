using UnityEngine;

/// <summary>
/// Controla el estado de la linterna del jugador, alternando entre apagado, linterna tipo1(iluminacion recta) y linterna tipo2(iluminacion panoramia).
/// </summary>
public class lightControl : MonoBehaviour
{
    /// <summary>
    /// Objeto que representa la linterna de mano.
    /// </summary>
    public GameObject LL;

    /// <summary>
    /// Objeto que representa la linterna de casco.
    /// </summary>
    public GameObject LP;

    /// <summary>
    /// Indica si el jugador ha recogido la linterna.
    /// </summary>
    public bool linterapick = true;

    /// <summary>
    /// Estado actual de la linterna:
    /// 0 - Apagada,
    /// 1 - Linterna de mano encendida,
    /// 2 - Linterna de casco encendida.
    /// </summary>
    private int estado = 0;

    /// <summary>
    /// Actualiza el estado de la linterna en cada fotograma.
    /// </summary>
    void Update()
    {
        if (!linterapick) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            estado++;

            if (estado > 2)
                estado = 0;

            switch (estado)
            {
                case 0:
                    LL.SetActive(false);
                    LP.SetActive(false);
                    break;
                case 1:
                    LL.SetActive(true);
                    LP.SetActive(false);
                    break;
                case 2:
                    LL.SetActive(false);
                    LP.SetActive(true);
                    break;
            }
        }
    }
}

using UnityEngine;

/// <summary>
/// Desactiva el GameObject asociado cuando el jugador ha recolectado una cantidad específica de motores en su inventario.
/// </summary>
public class Door : MonoBehaviour
{
    /// <summary>
    /// Verifica en cada frame si el jugador ha recolectado al menos 7 motores.
    /// Si es así, desactiva el GameObject para simular la apertura de una puerta.
    /// </summary>
    private void Update()
    {
        if (Inventario.Instancia != null && Inventario.Instancia.Motores >= 7)
        {
            gameObject.SetActive(false);
        }
    }
}
using UnityEngine;

/// <summary>
/// Activa un GameObject específico cuando el jugador ha recolectado una cantidad determinada de motores en su inventario.
/// </summary>
public class DoorOp : MonoBehaviour
{
    /// <summary>
    /// Referencia al GameObject que se activará al cumplir la condición.
    /// </summary>
    public GameObject opdoor;

    private bool puertaAbierta = false;

    /// <summary>
    /// Verifica en cada frame si el jugador ha recolectado al menos 7 motores.
    /// Si es así, activa el GameObject especificado y evita que se repita la activación.
    /// </summary>
    private void Update()
    {
        if (!puertaAbierta && Inventario.Instancia != null && Inventario.Instancia.Motores >= 7)
        {
            opdoor.SetActive(true);
            puertaAbierta = true;
        }
    }
}
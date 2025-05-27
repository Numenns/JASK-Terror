using UnityEngine;

/// <summary>
/// Controla la interacción con un objeto que solo puede usarse una vez.
/// </summary>
public class objInteractivo : MonoBehaviour
{
    /// <summary>
    /// Indica si el objeto ya ha sido usado.
    /// </summary>
    private bool yaUsado = false;

    /// <summary>
    /// Activa la lógica del objeto si no ha sido usado previamente.
    /// </summary>
    public void ActivarObjeto()
    {
        if (yaUsado) return;

        Debug.Log("¡Interacción con el objeto correcto: " + gameObject.name + "!");

        SpawnLLave manager = FindFirstObjectByType<SpawnLLave>();
        if (manager != null)
        {
            manager.UsarLugar(this.gameObject);
        }

        yaUsado = true;
    }
}
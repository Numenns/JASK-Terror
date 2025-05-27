using UnityEngine;

/// <summary>
/// Controla la interacción con un objeto que solo puede usarse una vez.
/// </summary>
/// 
public class objInteractivo : MonoBehaviour
{
    /// <summary>
    /// Activa la lógica del objeto si no ha sido usado previamente.
    /// </summary>
    
    private bool yaUsado = false;

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

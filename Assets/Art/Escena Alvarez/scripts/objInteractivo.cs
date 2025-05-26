using UnityEngine;

public class objInteractivo : MonoBehaviour
{
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

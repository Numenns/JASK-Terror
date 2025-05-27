using UnityEngine;
using UnityEngine.SceneManagement;

public class saltodeescenatemp : MonoBehaviour
{
    /// <summary>
    /// Nombre de la escena que se quiere cargar.
    /// </summary>
    public string nombreEscena;
    /// <summary>
    /// Método que se ejecuta cuando otro objeto entra en el collider de este objeto.
    /// Carga la escena especificada al detectar la colisión.
    /// </summary>
    /// <param name="other">El collider del objeto que ha colisionado.</param>
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}

using UnityEngine;

/// <summary>
/// Clase que representa un objeto interactivo que, al activarse, habilita otro objeto,
/// actualiza el estado de la linterna y reproduce un sonido de recogida antes de destruirse a sí mismo.
/// </summary>
public class ObjetoInteractivol : MonoBehaviour
{
    /// <summary>
    /// Indica si el objeto ya ha sido activado para evitar múltiples activaciones.
    /// </summary>
    private bool yaActivado = false;

    /// <summary>
    /// Objeto que se activará al interactuar con este objeto.
    /// </summary>
    public GameObject objetoAActivar;

    /// <summary>
    /// Clip de audio que se reproducirá al recoger el objeto.
    /// </summary>
    public AudioClip sonidoAlRecoger; // Asignar desde el Inspector

    /// <summary>
    /// Activa el objeto interactivo, habilita el objeto relacionado, actualiza el estado de la linterna,
    /// reproduce el sonido de recogida y destruye este objeto.
    /// </summary>
    public void ActivarObjeto()
    {
        if (!yaActivado)
        {
            yaActivado = true;

            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }

            lightControl lc = FindObjectOfType<lightControl>();
            if (lc != null)
            {
                lc.linterapick = true;
            }

            if (sonidoAlRecoger != null)
            {
                AudioSource.PlayClipAtPoint(sonidoAlRecoger, transform.position);
            }

            Destroy(gameObject);
        }
    }
}
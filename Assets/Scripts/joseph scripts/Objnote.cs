using UnityEngine;

/// <summary>
/// Componente para una nota coleccionable en el juego.
/// Muestra un mensaje cuando se apunta al objeto y permite recoger la nota, agregándola al inventario.
/// </summary>
public class ObjNote : MonoBehaviour
{
    /// <summary>
    /// UI que se muestra cuando el jugador apunta al objeto.
    /// </summary>
    [Header("Mensaje mostrado al mirar el objeto")]
    public GameObject mensajeUI;

    /// <summary>
    /// Texto que se guarda en el inventario al recoger la nota.
    /// </summary>
    [Header("Texto que se guarda al recoger")]
    [TextArea]
    public string textoNota;

    /// <summary>
    /// Sonido que se reproduce al recoger la nota.
    /// </summary>
    [Header("Sonido al recoger la nota")]
    public AudioClip sonidoRecoger;

    private bool recogido = false;
    private AudioSource audioSource;

    /// <summary>
    /// Inicializa el componente buscando o agregando un AudioSource.
    /// </summary>
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Devuelve si la nota está disponible para ser recogida.
    /// </summary>
    public bool EstaDisponible()
    {
        return !recogido && gameObject.activeInHierarchy;
    }

    /// <summary>
    /// Muestra el mensaje de UI si la nota está disponible.
    /// </summary>
    public void MostrarMensaje()
    {
        if (EstaDisponible() && mensajeUI != null)
        {
            mensajeUI.SetActive(true);
        }
    }

    /// <summary>
    /// Oculta el mensaje de UI.
    /// </summary>
    public void OcultarMensaje()
    {
        if (mensajeUI != null)
        {
            mensajeUI.SetActive(false);
        }
    }

    /// <summary>
    /// Recoge la nota: reproduce sonido, guarda el texto en el inventario, oculta el mensaje y desactiva el objeto.
    /// </summary>
    public void ActivarObjeto()
    {
        if (EstaDisponible())
        {
            recogido = true;

            if (sonidoRecoger != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoRecoger);
            }

            Debug.Log("Texto a añadir al inventario: " + textoNota);

            if (Inventario.Instancia != null)
            {
                Inventario.Instancia.AgregarNota(textoNota);
                Debug.Log("Se agregó al inventario: " + textoNota);
            }

            OcultarMensaje();
            StartCoroutine(DesactivarTrasSonido());
        }
    }

    /// <summary>
    /// Espera a que termine el sonido (si hay) y desactiva el objeto.
    /// </summary>
    private System.Collections.IEnumerator DesactivarTrasSonido()
    {
        if (sonidoRecoger != null)
        {
            yield return new WaitForSeconds(sonidoRecoger.length);
        }
        gameObject.SetActive(false);
    }
}

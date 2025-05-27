using UnityEngine;

/// <summary>
/// Representa un objeto interactivo que, al activarse, incrementa el contador de motores en el inventario,
/// activa un objeto relacionado y reproduce un sonido de activación.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class ObjetoInteractivo : MonoBehaviour
{
    /// <summary>
    /// Objeto que se activará al interactuar con este objeto.
    /// </summary>
    [Header("Configuración")]
    public GameObject objetoAActivar;

    /// <summary>
    /// Clip de audio que se reproducirá al activar el objeto.
    /// </summary>
    [Header("Audio")]
    public AudioClip sonidoActivacion;

    private AudioSource audioSource;
    private bool yaActivado = false;

    /// <summary>
    /// Inicializa el componente AudioSource.
    /// </summary>
    private void Start()
    {
        // Asegura que el objeto tenga un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Activa el objeto interactivo, incrementa el contador de motores, activa el objeto relacionado y reproduce el sonido de activación.
    /// </summary>
    public void ActivarObjeto()
    {
        if (yaActivado) return;

        yaActivado = true;

        // Aumenta el contador de motores solo si Inventario está disponible
        if (Inventario.Instancia != null)
        {
            Inventario.Instancia.Motores += 1;
        }
        else
        {
            Debug.LogWarning("Inventario.Instancia es null. ¿Olvidaste colocarlo en la escena?");
        }

        // Elimina la posibilidad de volver a interactuar
        gameObject.tag = "Untagged";

        // Activa el objeto si está asignado
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }

        // Reproduce el sonido si está asignado
        if (sonidoActivacion != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoActivacion);
        }
    }
}

using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject objetoAActivar;

    [Header("Audio")]
    public AudioClip sonidoActivacion;

    private AudioSource audioSource;
    private bool yaActivado = false;

    private void Start()
    {
        // Asegura que el objeto tenga un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

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
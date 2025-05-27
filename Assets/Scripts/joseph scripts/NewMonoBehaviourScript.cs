using UnityEngine;

/// <summary>
/// Clase que reproduce un sonido de forma repetitiva a intervalos definidos.
/// </summary>
public class SoundRepeaterR : MonoBehaviour
{
    /// <summary>
    /// Clip de audio que se reproducirá.
    /// </summary>
    [Header("Audio Settings")]
    public AudioClip sonido;

    /// <summary>
    /// Intervalo de tiempo en segundos entre cada reproducción del sonido.
    /// </summary>
    public float intervalo = 2f;

    /// <summary>
    /// Componente AudioSource utilizado para reproducir el sonido.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Tiempo en el que se programará la siguiente reproducción del sonido.
    /// </summary>
    private float tiempoSiguiente;

    /// <summary>
    /// Inicializa el componente AudioSource y programa la primera reproducción del sonido.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = sonido;
        tiempoSiguiente = Time.time + intervalo;
    }

    /// <summary>
    /// Verifica si es momento de reproducir el sonido nuevamente en cada frame.
    /// </summary>
    void Update()
    {
        if (Time.time >= tiempoSiguiente)
        {
            ReproducirSonido();
            tiempoSiguiente = Time.time + intervalo;
        }
    }

    /// <summary>
    /// Reproduce el clip de audio una vez utilizando PlayOneShot.
    /// </summary>
    void ReproducirSonido()
    {
        if (sonido != null)
        {
            audioSource.PlayOneShot(sonido);
        }
    }
}

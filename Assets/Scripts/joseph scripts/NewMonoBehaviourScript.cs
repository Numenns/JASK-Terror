using UnityEngine;

public class SoundRepeater : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip sonido; // Sonido asignado desde el inspector
    public float intervalo = 2f; // Tiempo en segundos entre reproducciones

    private AudioSource audioSource;
    private float tiempoSiguiente;

    void Start()
    {
        // Añadir un AudioSource si no existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = sonido;
        tiempoSiguiente = Time.time + intervalo;
    }

    void Update()
    {
        if (Time.time >= tiempoSiguiente)
        {
            ReproducirSonido();
            tiempoSiguiente = Time.time + intervalo;
        }
    }

    void ReproducirSonido()
    {
        if (sonido != null)
        {
            audioSource.PlayOneShot(sonido);
        }
    }
}
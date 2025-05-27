using UnityEngine;

/// <summary>
/// Reproduce un sonido de forma periódica cuando el jugador se encuentra dentro de una zona determinada(enemigo).
/// El volumen del sonido varía en función de la proximidad del jugador al centro de la zona.
/// </summary>
public class audioprox : MonoBehaviour
{
    /// <summary>
    /// Referencia al objeto del jugador cuya posición se utiliza para calcular la proximidad.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Volumen máximo al que se puede reproducir el sonido.
    /// </summary>
    public float maxVolume = 1f;

    /// <summary>
    /// Intervalo de tiempo en segundos entre cada reproducción del sonido.
    /// </summary>
    public float playInterval = 3f;

    private Collider zone;
    private AudioSource audioSrc;
    private float timer;

    /// <summary>
    /// Inicializa los componentes necesarios y verifica su existencia.
    /// </summary>
    private void Start()
    {
        zone = GetComponent<Collider>();
        audioSrc = GetComponent<AudioSource>();

        if (zone == null || audioSrc == null)
        {
            Debug.LogError("Falta un Collider o AudioSource en " + gameObject.name);
            enabled = false;
            return;
        }

        audioSrc.loop = false;
        timer = playInterval;
    }

    /// <summary>
    /// Actualiza el temporizador y reproduce el sonido si el jugador está dentro de la zona.
    /// El volumen se ajusta según la distancia del jugador al centro de la zona.
    /// </summary>
    private void Update()
    {
        if (zone.bounds.Contains(player.position))
        {
            float dist = Vector3.Distance(player.position, zone.bounds.center);
            float maxDist = zone.bounds.extents.magnitude;
            float volume = Mathf.Clamp01(1 - (dist / maxDist)) * maxVolume;

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                audioSrc.volume = volume;
                audioSrc.Play();
                timer = playInterval;
            }
        }
        else
        {
            timer = playInterval;
        }
    }
}
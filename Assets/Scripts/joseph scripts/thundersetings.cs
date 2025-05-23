using UnityEngine;

public class thundersetings : MonoBehaviour
{
    [Header("Referencia a la luz direccional")]
    [SerializeField] private Light luzDireccional;

    [Header("Parámetros del Ciclo")]
    [SerializeField] private float duracionCiclo = 5f;           // Duración de subida + oscilación + bajada
    [SerializeField] private float intervaloEntreCiclos = 10f;   // Cada cuánto se repite todo el ciclo

    [Header("Iluminación")]
    [SerializeField] private float intensidadMaxima = 1f;
    [SerializeField] private float duracionOscilacion = 1f;
    [SerializeField] private int cantidadOscilaciones = 3;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource; // Solo uno

    private float tiempoActual = 0f;
    private bool cicloActivo = false;
    private bool sonidoReproducido = false;

    private void Start()
    {
        if (luzDireccional == null)
            Debug.LogError("Debes asignar una luz direccional.");
        if (audioSource == null)
            Debug.LogError("Debes asignar un AudioSource.");
    }

    private void Update()
    {
        if (luzDireccional == null || audioSource == null) return;

        tiempoActual += Time.deltaTime;

        if (tiempoActual >= intervaloEntreCiclos)
        {
            tiempoActual = 0f;
            cicloActivo = true;
            sonidoReproducido = false;
        }

        if (tiempoActual <= duracionCiclo)
        {
            cicloActivo = true;
            if (!sonidoReproducido)
            {
                audioSource.Play(); // Usa el clip asignado al AudioSource
                Debug.Log("Sonido de trueno reproducido."); // Este mensaje aparecerá en la consola
                sonidoReproducido = true;
            }

            float t = tiempoActual;
            float mitadCiclo = duracionCiclo / 2f;
            float intensidad = 0f;

            if (t < mitadCiclo - duracionOscilacion)
            {
                float subeT = t / (mitadCiclo - duracionOscilacion);
                intensidad = Mathf.Lerp(0f, intensidadMaxima * 0.9f, subeT);
            }
            else if (t < mitadCiclo)
            {
                float oscT = (t - (mitadCiclo - duracionOscilacion)) / duracionOscilacion;
                float oscilacion = Mathf.Sin(oscT * Mathf.PI * cantidadOscilaciones);
                intensidad = Mathf.Lerp(intensidadMaxima * 0.9f, intensidadMaxima, oscT) + oscilacion * 0.1f * intensidadMaxima;
            }
            else
            {
                float bajaT = (t - mitadCiclo) / (duracionCiclo - mitadCiclo);
                intensidad = Mathf.Lerp(intensidadMaxima, 0f, bajaT);
            }

            luzDireccional.intensity = Mathf.Clamp(intensidad, 0f, intensidadMaxima);
        }
        else
        {
            cicloActivo = false;
            luzDireccional.intensity = 0f;
        }
    }
}
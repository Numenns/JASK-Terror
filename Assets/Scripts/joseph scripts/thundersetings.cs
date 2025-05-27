using UnityEngine;

/// <summary>
/// Controla un efecto de trueno cíclico que incluye iluminación y sonido en Unity.
/// </summary>
public class thundersetings : MonoBehaviour
{
    /// <summary>
    /// Luz direccional que simula el relámpago.
    /// </summary>
    [SerializeField] private Light luzDireccional;

    /// <summary>
    /// Duración total del ciclo de trueno en segundos.
    /// </summary>
    [SerializeField] private float duracionCiclo = 5f;

    /// <summary>
    /// Intervalo de tiempo entre cada ciclo de trueno en segundos.
    /// </summary>
    [SerializeField] private float intervaloEntreCiclos = 10f;

    /// <summary>
    /// Intensidad máxima que alcanza la luz durante el trueno.
    /// </summary>
    [SerializeField] private float intensidadMaxima = 1f;

    /// <summary>
    /// Duración de la fase de oscilación de la luz en segundos.
    /// </summary>
    [SerializeField] private float duracionOscilacion = 1f;

    /// <summary>
    /// Número de oscilaciones de la luz durante la fase de oscilación.
    /// </summary>
    [SerializeField] private int cantidadOscilaciones = 3;

    /// <summary>
    /// Fuente de audio que reproduce el sonido del trueno.
    /// </summary>
    [SerializeField] private AudioSource audioSource;

    /// <summary>
    /// Tiempo transcurrido desde el inicio o desde el último ciclo.
    /// </summary>
    private float tiempoActual = 0f;

    /// <summary>
    /// Indica si el ciclo de trueno está activo.
    /// </summary>
    private bool cicloActivo = false;

    /// <summary>
    /// Indica si el sonido del trueno ya ha sido reproducido en el ciclo actual.
    /// </summary>
    private bool sonidoReproducido = false;

    /// <summary>
    /// Inicializa las referencias y verifica que se hayan asignado correctamente.
    /// </summary>
    private void Start()
    {
        if (luzDireccional == null)
            Debug.LogError("Debes asignar una luz direccional.");
        if (audioSource == null)
            Debug.LogError("Debes asignar un AudioSource.");
    }

    /// <summary>
    /// Actualiza el estado del ciclo de trueno, controlando la iluminación y el sonido.
    /// </summary>
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
                audioSource.Play();
                Debug.Log("Sonido de trueno reproducido.");
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

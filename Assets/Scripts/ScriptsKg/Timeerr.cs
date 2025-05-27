using TMPro;
using UnityEngine;

/// <summary>
/// Controla un temporizador de cuenta regresiva y el comportamiento de duplicación de partículas.
/// También muestra el tiempo transcurrido en pantalla y activa el estado de Game Over si se supera un tiempo límite.
/// </summary>
public class Timeerr : MonoBehaviour
{
    /// <summary>
    /// Tiempo máximo en minutos antes de activar el estado de Game Over.
    /// </summary>
    [SerializeField] private float tiempomaximo = 3;

    /// <summary>
    /// Sistema de partículas que se duplicará con el tiempo.
    /// </summary>
    [SerializeField] private ParticleSystem particulas;

    /// <summary>
    /// Referencia al script que maneja la lógica de recolectables y que activará el Game Over.
    /// </summary>
    [SerializeField] private RayRecolectables rayRecolectables;

    /// <summary>
    /// Tiempo actual transcurrido desde el inicio del temporizador.
    /// </summary>
    private float tiempoActual = 0f;

    /// <summary>
    /// Indica si el temporizador está activo.
    /// </summary>
    private bool tiempoActivado = false;

    /// <summary>
    /// Texto UI para mostrar el tiempo transcurrido (minutos:segundos).
    /// </summary>
    public TextMeshProUGUI temp;

    /// <summary>
    /// Indica si ha comenzado la duplicación de partículas.
    /// </summary>
    private bool empezarDuplicacion = false;

    /// <summary>
    /// Marca el tiempo de la última duplicación de partículas.
    /// </summary>
    private float tiempoUltimaDuplicacion = 0f;

    /// <summary>
    /// Intervalo en segundos entre duplicaciones de partículas.
    /// </summary>
    private float intervaloDuplicacion = 5f;

    /// <summary>
    /// Contador de cuántas veces se han duplicado las partículas.
    /// </summary>
    private int contadorDuplicados = 0;

    /// <summary>
    /// Inicializa y activa el temporizador al iniciar el juego.
    /// </summary>
    private void Start()
    {
        ActivarTemporizador();
    }

    /// <summary>
    /// Actualiza el temporizador cada frame y controla la lógica de Game Over y duplicación de partículas.
    /// </summary>
    void Update()
    {
        if (tiempoActivado)
        {
           
            tiempoActual += Time.deltaTime;

           
            int minutos = Mathf.FloorToInt(tiempoActual / 60);
            int segundos = Mathf.FloorToInt(tiempoActual % 60);
            temp.text = minutos + ":" + segundos.ToString("D2");

        
            if (tiempoActual >= tiempomaximo * 60)
            {
                Debug.Log("Derrota por tiempo");
                tiempoActivado = false;

            
                if (rayRecolectables != null)
                    rayRecolectables.ActivarGameOver();
            }
            if (!empezarDuplicacion && tiempoActual >= 60f)
            {
                empezarDuplicacion = true;
                tiempoUltimaDuplicacion = tiempoActual;
            }

            
            if (empezarDuplicacion && tiempoActual - tiempoUltimaDuplicacion >= intervaloDuplicacion)
            {
                DuplicarParticulas();
                tiempoUltimaDuplicacion = tiempoActual;
            }
        }
    }

    /// <summary>
    /// Duplica el sistema de partículas en una nueva posición con un desplazamiento horizontal.
    /// </summary>
    private void DuplicarParticulas()
    {
        if (particulas != null)
        {
            Vector3 offset = new Vector3(contadorDuplicados * 1.9f, 0, 0);
            Instantiate(particulas, particulas.transform.position + offset, Quaternion.identity);
            contadorDuplicados++;
            Debug.Log("Partículas duplicadas #" + contadorDuplicados);
        }
    }

    /// <summary>
    /// Reinicia y activa el temporizador, así como los parámetros de duplicación.
    /// </summary>
    public void ActivarTemporizador()
    {
        tiempoActual = 0;
        tiempoActivado = true;
        empezarDuplicacion = false;
        tiempoUltimaDuplicacion = 0f;
        contadorDuplicados = 0;
    }

    /// <summary>
    /// Detiene el temporizador actual sin reiniciar los valores.
    /// </summary>
    public void DesactivarTemporizador()
    {
        tiempoActivado = false;
    }
}
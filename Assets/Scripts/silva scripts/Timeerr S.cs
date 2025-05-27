using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Clase que gestiona un temporizador de cuenta regresiva, que cambia el color de la luz, el texto y un material
/// según el progreso del tiempo. Al finalizar el tiempo o al cumplir la condición de victoria, actualiza el estado del juego.
/// </summary>
public class TimeerrS: MonoBehaviour
{
    [SerializeField] private float tiempomaximo = 3;
    /// <summary>
    /// Tiempo actual transcurrido en segundos.
    /// </summary>
    private float tiempoActual = 0f;
    /// <summary>
    /// Indica si el temporizador está activo.
    /// </summary>
    private bool tiempoActivado = false;
    /// <summary>
    /// TextMeshProUGUI que muestra el tiempo transcurrido.
    /// </summary>
    public TextMeshProUGUI temp;
    /// <summary>
    /// Luz de la pantalla.
    /// </summary>
    public Light luz;
    /// <summary>
    /// material de la pantalla.
    /// </summary>
    public Material pantalla;


    /// <summary>
    /// Inicializa el temporizador al activar el script.
    /// </summary>
    private void Start()
    {
        ActivarTemporizador();
    }
    /// <summary>
    /// Actualiza el temporizador cada frame y cambia los colores de los objetos asociados, acomoda los segundos en minutos y 
    /// indica si el jugador a perdido o ganado.
    /// </summary>
    void Update()
    {
        if (tiempoActivado)
        {
            tiempoActual += Time.deltaTime;
            float T = tiempomaximo * 60;

            float progreso = Mathf.Clamp01(tiempoActual / T); // 0 a 1 en el tiempo maximo

            // Cambiar hue de 0.33 (verde) a 0.0 (rojo)
            float hue = Mathf.Lerp(0.33f, 0.0f, progreso);
            float saturation = 1f;
            float value = 1f;

            luz.color = Color.HSVToRGB(hue, saturation, value);
            temp.color = Color.HSVToRGB(hue, saturation, value);
            pantalla.color = Color.HSVToRGB(hue, saturation, value);
            int minutos = Mathf.FloorToInt(tiempoActual / 60);
            int segundos = Mathf.FloorToInt(tiempoActual % 60);
            temp.text = minutos + ":" + segundos;

            if (tiempoActual >= tiempomaximo * 60)
            {
                temp.text = "";
                Inventario.Instancia.Perdiste=true;
                DesactivarTemporizador();
            }
            if (Inventario.Instancia.Cuenta==6)
            {
                DesactivarTemporizador();
                Inventario.Instancia.Ganaste = true;
            }
            
        }

    }
    /// <summary>
    /// Activa el temporizador y reinicia el tiempo.
    /// </summary>
    public void ActivarTemporizador()
    {
        tiempoActual = 0;
        tiempoActivado = true;

    }
    /// <summary>
    /// Desactiva el temporizador.
    /// </summary>
    public void DesactivarTemporizador()
    {
        tiempoActivado = false;
    }
}
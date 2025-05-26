using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class TimeerrS: MonoBehaviour
{
    [SerializeField] private float tiempomaximo = 3;

    private float tiempoActual = 0f;
    private bool tiempoActivado = false;
    public TextMeshProUGUI temp;
    public Light luz;
    public Material pantalla;



    private void Start()
    {
        ActivarTemporizador();
    }
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
                GameManager.Instance.Perdiste=true;
                DesactivarTemporizador();
            }
            if (GameManager.Instance.Cuenta==6)
            {
                DesactivarTemporizador();
                GameManager.Instance.Ganaste = true;
            }
            
        }

    }

    public void ActivarTemporizador()
    {
        tiempoActual = 0;
        tiempoActivado = true;

    }

    public void DesactivarTemporizador()
    {
        tiempoActivado = false;
    }
}
using TMPro;
using UnityEngine;


public class Timeerr: MonoBehaviour
{
    [SerializeField] private float tiempomaximo = 3;
    [SerializeField] private ParticleSystem particulas;

    private float tiempoActual = 0f;
    private bool tiempoActivado = false;
    public TextMeshProUGUI temp;

    private bool empezarDuplicacion = false;
    private float tiempoUltimaDuplicacion = 0f;
    private float intervaloDuplicacion = 5f; 
    private int contadorDuplicados = 0;


    private void Start()
    {
        ActivarTemporizador();
    }
    void Update()
    {
        if (tiempoActivado)
        {
            tiempoActual += Time.deltaTime;

            int minutos = Mathf.FloorToInt(tiempoActual / 60);
            int segundos = Mathf.FloorToInt(tiempoActual % 60);
            temp.text = minutos + ":" + segundos;

            if (tiempoActual >= tiempomaximo * 60)
            {
                Debug.Log("Derrota");
                DesactivarTemporizador();
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

    public void ActivarTemporizador()
    {
        tiempoActual = 0;
        tiempoActivado = true;
        empezarDuplicacion = false;
        tiempoUltimaDuplicacion = 0f;
        contadorDuplicados = 0;
    }

    public void DesactivarTemporizador()
    {
        tiempoActivado = false;
    }
}
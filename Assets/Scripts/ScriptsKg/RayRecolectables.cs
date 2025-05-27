using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla la recolección de historias clínicas en el juego.
/// Maneja la interacción con objetos, conteo, mensajes aleatorios,
/// advertencias y transiciones de escena.
/// </summary>

public class RayRecolectables : MonoBehaviour
{
    /// <summary>Distancia máxima para interactuar con un objeto.</summary>
    public float distanciaInteraccion = 3f;

    /// <summary>Layer que contiene los objetos de tipo Historia Clínica.</summary>
    public LayerMask capaHistoriaClin;

    /// <summary>Texto en pantalla que muestra el contador de historias recolectadas.</summary>
    public TextMeshProUGUI contadorTexto;

    /// <summary>Texto en pantalla que muestra los mensajes médicos aleatorios.</summary>
    public TextMeshProUGUI mensajeTexto;

    /// <summary>Canvas que se activa al entrar en zona peligrosa.</summary>
    public GameObject canvasAdvertencia;

    /// <summary>Canvas que se muestra cuando se recolectan todas las historias.</summary>
    public GameObject canvasWinner;

    /// <summary>Nombre de la siguiente escena a cargar al completar el objetivo.</summary>
    public string siguienteEscena = "escenaSilva";

    private int historiasRecolectadas = 0;
    private int totalHistorias = 5;

    private bool gameOver = false;
    private bool estaEnZonaPeligro = false;

    private float tiempoGameOver = 0f;
    private float delayGameOver = 4f;
    /// <summary>Mensajes que se muestran al recolectar historias clínicas.</summary>
    private string[] mensajesMedicos = {
        "Ingreso de urgencias a hospital con estado delicado",
        "Contusión, lesiones",
        "Convulsión grave",
        "TU ESTADO ES CRÍTICO",
        "INGRESA A URGENCIAS, EN LA CIRUGÍA SOLO TE PUEDES SALVAR TÚ"
    };
    /// <summary>
    /// Inicializa los textos y desactiva los canvas al comenzar.
    /// </summary>
    void Start()
    {
        ActualizarContador();
        mensajeTexto.text = "";
        if (canvasAdvertencia != null)
            canvasAdvertencia.SetActive(false);
        if (canvasWinner != null)
            canvasWinner.SetActive(false);
    }
    /// <summary>
    /// Maneja la lógica de recolección, cambio de escena y zonas peligrosas.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, distanciaInteraccion, capaHistoriaClin))
            {
                GameObject objetoGolpeado = hit.collider.gameObject;

                if (objetoGolpeado.CompareTag("Historiaclinica") &&
                    objetoGolpeado.layer == LayerMask.NameToLayer("HistoriaClin"))
                {
                    Destroy(objetoGolpeado);
                    historiasRecolectadas++;
                    ActualizarContador();
                    MostrarMensajeAleatorio();
                }
            }
        }

        if (historiasRecolectadas >= totalHistorias && !gameOver)
        {
            if (canvasWinner != null)
                canvasWinner.SetActive(true);

            SceneManager.LoadScene(siguienteEscena);
        }

        if (estaEnZonaPeligro)
        {
            tiempoGameOver += Time.deltaTime;
            if (tiempoGameOver >= delayGameOver && !gameOver)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                gameOver = true;
            }
        }
    }
    /// <summary>
    /// Actualiza el texto del contador de historias clínicas recolectadas.
    /// </summary>
    void ActualizarContador()
    {
        contadorTexto.text = historiasRecolectadas + "/" + totalHistorias;
    }
    /// <summary>
    /// Muestra un mensaje médico aleatorio y lo limpia luego de un tiempo.
    /// </summary>
    void MostrarMensajeAleatorio()
    {
        string mensaje = mensajesMedicos[Random.Range(0, mensajesMedicos.Length)];
        mensajeTexto.text = mensaje;
        CancelInvoke(nameof(LimpiarMensaje));
        Invoke(nameof(LimpiarMensaje), 3f);
    }
    /// <summary>
    /// Limpia el mensaje médico mostrado en pantalla.
    /// </summary>
    void LimpiarMensaje()
    {
        mensajeTexto.text = "";
    }
    /// <summary>
    /// Activa el canvas de advertencia y comienza la cuenta regresiva para el Game Over.
    /// </summary>
    public void ActivarGameOver()
    {
        if (canvasAdvertencia != null)
            canvasAdvertencia.SetActive(true);

        estaEnZonaPeligro = true;
        tiempoGameOver = 0f;
    }


    /// <summary>
    /// Cancela el Game Over y desactiva el canvas de advertencia.
    /// </summary>

    public void CancelarGameOver()
    {
        estaEnZonaPeligro = false;
        tiempoGameOver = 0f;

        if (canvasAdvertencia != null)
            canvasAdvertencia.SetActive(false);
    }
}

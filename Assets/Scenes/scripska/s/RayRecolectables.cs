using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayRecolectables : MonoBehaviour
{
    public float distanciaInteraccion = 2f;
    public LayerMask capaHistoriaClin;

    public TextMeshProUGUI contadorTexto;
    public TextMeshProUGUI mensajeTexto;

    public GameObject canvasAdvertencia;
    public string siguienteEscena = "escenaSilva";
    public string escenaDerrota = "Menu";

    private int historiasRecolectadas = 0;
    private int totalHistorias = 5;

    private bool gameOver = false;

    private float tiempoGameOver = 0f;
    private float delayGameOver = 2f;

    private string[] mensajesMedicos = {
        "Ingreso de urgencias a hospital con estado delicado",
        "Contusión, lesiones",
        "Convulsión grave",
        "TU ESTADO ES CRÍTICO",
        "INGRESA A URGENCIAS, EN LA CIRUGÍA SOLO TE PUEDES SALVAR TÚ"
    };

    void Start()
    {
        ActualizarContador();
        mensajeTexto.text = "";
        if (canvasAdvertencia != null)
            canvasAdvertencia.SetActive(false);
    }

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

        // Si ganó
        if (historiasRecolectadas >= totalHistorias && !gameOver)
        {
            SceneManager.LoadScene(siguienteEscena);
        }

        // Si perdió por fuego
        if (gameOver)
        {
            tiempoGameOver += Time.deltaTime;
            if (tiempoGameOver >= delayGameOver)
            {
                SceneManager.LoadScene(escenaDerrota);
            }
        }
    }

    void ActualizarContador()
    {
        contadorTexto.text = historiasRecolectadas + "/" + totalHistorias;
    }

    void MostrarMensajeAleatorio()
    {
        string mensaje = mensajesMedicos[Random.Range(0, mensajesMedicos.Length)];
        mensajeTexto.text = mensaje;
        CancelInvoke(nameof(LimpiarMensaje));
        Invoke(nameof(LimpiarMensaje), 3f);
    }

    void LimpiarMensaje()
    {
        mensajeTexto.text = "";
    }

    public void ActivarGameOver()
    {
        if (canvasAdvertencia != null)
            canvasAdvertencia.SetActive(true);

        gameOver = true;
        tiempoGameOver = 0f;
    }
}

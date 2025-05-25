using TMPro;
using UnityEngine;

public class RayRecolectables : MonoBehaviour
{
    public float distanciaInteraccion = 2f;
    public LayerMask capaHistoriaClin;

    public TextMeshProUGUI contadorTexto;
    public TextMeshProUGUI mensajeTexto;

    private int historiasRecolectadas = 0;
    private int totalHistorias = 5;

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
    }

    void Update()
    {
      
      

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaInteraccion, capaHistoriaClin))
            {
                GameObject objetoGolpeado = hit.collider.gameObject;

                if (objetoGolpeado.CompareTag("Historiaclinica") &&
                    objetoGolpeado.layer == LayerMask.NameToLayer("HistoriaClin"))
                {
                    Debug.Log("Historia clínica destruida: " + objetoGolpeado.name);
                    Destroy(objetoGolpeado);
                    historiasRecolectadas++;
                    ActualizarContador();
                    MostrarMensajeAleatorio();
                }
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
    public int GetContador()
    {
        return historiasRecolectadas;
    }

    void LimpiarMensaje()
    {
        mensajeTexto.text = "";
    }
}
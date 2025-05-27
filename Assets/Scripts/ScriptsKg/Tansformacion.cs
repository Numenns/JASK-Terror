using UnityEngine;

/// <summary>
/// Controla la transformación temporal del personaje al interactuar con objetos de medicina.
/// Aumenta su tamaño por 10 segundos y luego vuelve al tamaño original.
/// </summary>
public class Transformacion : MonoBehaviour
{
    /// <summary>
    /// Distancia máxima para detectar objetos interactuables al frente del personaje.
    /// </summary>
    public float distanciaInteraccion = 1.5f;

    /// <summary>
    /// Capa que identifica los objetos que se pueden interactuar (como la medicina).
    /// </summary>
    public LayerMask capaMedicina;

    /// <summary>
    /// Canvas que se activa cuando el personaje está creciendo.
    /// </summary>
    public GameObject canvasCreciendo;

    /// <summary>
    /// Canvas que se activa cuando el personaje regresa a su tamaño original.
    /// </summary>
    public GameObject canvasRegresando;

    /// <summary>
    /// Escala original del personaje (antes de crecer).
    /// </summary>
    private Vector3 escalaOriginal;

    /// <summary>
    /// Indica si el personaje se encuentra en estado de crecimiento.
    /// </summary>
    private bool estaCreciendo = false;

    /// <summary>
    /// Tiempo restante para mantener al personaje en tamaño aumentado.
    /// </summary>
    private float tiempoCrecimientoRestante = 0f;

    /// <summary>
    /// Inicializa variables y oculta los canvas.
    /// </summary>
    void Start()
    {
        escalaOriginal = transform.localScale;
        if (canvasCreciendo) canvasCreciendo.SetActive(false);
        if (canvasRegresando) canvasRegresando.SetActive(false);
    }

    /// <summary>
    /// Detecta entrada del jugador y controla la lógica de crecimiento y regresión del personaje.
    /// </summary>
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * distanciaInteraccion, Color.red);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaInteraccion, capaMedicina))
            {
                GameObject objeto = hit.collider.gameObject;
                if (objeto.CompareTag("Medicine"))
                {
                    Destroy(objeto);
                    if (!estaCreciendo)
                    {
                        ActivarCrecimiento();
                    }
                }
            }
        }

        // Control del tiempo de crecimiento
        if (estaCreciendo)
        {
            tiempoCrecimientoRestante -= Time.deltaTime;

            if (tiempoCrecimientoRestante <= 2f && canvasCreciendo.activeSelf)
            {
                canvasCreciendo.SetActive(false);
                canvasRegresando.SetActive(true);
            }

            if (tiempoCrecimientoRestante <= 0f)
            {
                transform.localScale = escalaOriginal;
                canvasRegresando.SetActive(false);
                estaCreciendo = false;
            }
        }
    }

    /// <summary>
    /// Activa el estado de crecimiento: aumenta la escala y muestra el canvas de crecimiento.
    /// </summary>
    void ActivarCrecimiento()
    {
        estaCreciendo = true;
        tiempoCrecimientoRestante = 10f;
        transform.localScale = escalaOriginal * 2f;

        if (canvasCreciendo) canvasCreciendo.SetActive(true);
        if (canvasRegresando) canvasRegresando.SetActive(false);
    }
}

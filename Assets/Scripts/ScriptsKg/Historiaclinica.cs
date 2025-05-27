using UnityEngine;

/// <summary>
/// Controla el comportamiento de un objeto tipo Historia Clínica.
/// Reproduce una animación al ser activado por el jugador y se destruye después.
/// </summary>
public class HistoriaClinica : MonoBehaviour
{
    /// <summary>
    /// Referencia al componente Animator del objeto.
    /// Se utiliza para activar la animación de destrucción.
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Indica si el objeto ya inició su proceso de destrucción para evitar activaciones múltiples.
    /// </summary>
    private bool yaDestruyendose = false;

    /// <summary>
    /// Inicializa el componente Animator y verifica su existencia.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Falta el componente Animator en " + gameObject.name);
        }
    }

    /// <summary>
    /// Detecta colisiones con el jugador y, si se cumplen las condiciones,
    /// activa la animación de destrucción del objeto.
    /// </summary>
    /// <param name="other">El collider que entra en contacto con el objeto.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!yaDestruyendose && other.CompareTag("Player"))
        {
            
            if (CompareTag("Historiaclinica") && gameObject.layer == LayerMask.NameToLayer("HistoriaClin"))
            {
                yaDestruyendose = true;
                animator.SetTrigger("Destruir");
            }
        }
    }

    /// <summary>
    /// Método llamado desde el evento de animación.
    /// Se encarga de destruir el objeto del juego.
    /// </summary>
    public void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
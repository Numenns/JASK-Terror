using UnityEngine;

/// <summary>
/// Detecta la entrada del jugador en una zona peligrosa (fuego) y activa efectos visuales.
/// Tambien puede activar o cancelar el estado de Game Over a traves del sistema RayRecolectables.
/// </summary>
public class DetectorFuego : MonoBehaviour
{
    /// <summary>
    /// Grupo de UI que se hará parpadear al detectar al jugador.
    /// </summary>
    public CanvasGroup canvasGroup;

    /// <summary>
    /// Duracion del efecto de fundido (fade) para el parpadeo, en segundos.
    /// </summary>
    public float fadeDuration = 1f;

    private bool estaParpadeando = false;
    private float tiempoParpadeo = 0f;
    private bool yendoHaciaArriba = true;

    /// <summary>
    /// Se llama automaticamente cuando otro collider entra en contacto con este trigger.
    /// Activa el parpadeo visual y notifica a RayRecolectables para activar el Game Over.
    /// </summary>
    /// <param name="other">Collider que ha entrado en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaParpadeando = true;
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            tiempoParpadeo = 0f;
            yendoHaciaArriba = true;

            RayRecolectables recolector = FindFirstObjectByType<RayRecolectables>();
            if (recolector != null)
            {
                recolector.ActivarGameOver();
            }
        }
    }

    /// <summary>
    /// Se llama automáticamente cuando otro collider sale de este trigger.
    /// Detiene el parpadeo visual y notifica a RayRecolectables para cancelar el Game Over.
    /// </summary>
    /// <param name="other">Collider que ha salido del trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaParpadeando = false;

           
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            RayRecolectables recolector = FindFirstObjectByType<RayRecolectables>();
            if (recolector != null)
            {
                recolector.CancelarGameOver();
            }
        }
    }

    /// <summary>
    /// Actualiza el estado del parpadeo visual cada frame si el jugador está dentro del área.
    /// </summary>
    private void Update()
    {
        if (estaParpadeando)
        {
        
            tiempoParpadeo += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoParpadeo / fadeDuration);

            if (yendoHaciaArriba)
            {
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            }
            else
            {
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            }

            if (tiempoParpadeo >= fadeDuration)
            {
                tiempoParpadeo = 0f;
                yendoHaciaArriba = !yendoHaciaArriba;
            }
        }
    }
}
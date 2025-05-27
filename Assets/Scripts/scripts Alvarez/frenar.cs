using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Detiene el movimiento y la animación de un enemigo cuando es detectado por un raycast.
/// </summary>
public class MirarParaEnemigo : MonoBehaviour
{
    /// <summary>
    /// Distancia máxima del raycast para detectar al enemigo.
    /// </summary>
    public float distancia = 15f;

    /// <summary>
    /// Tag del objeto enemigo a detectar.
    /// </summary>
    public string tagEnemigo = "Enemigo";

    /// <summary>
    /// Nombre del script de IA que controla al enemigo.
    /// </summary>
    public string nombreScriptAI = "EnemyAI";

    /// <summary>
    /// Referencia al script de IA del enemigo detectado actualmente.
    /// </summary>
    private MonoBehaviour scriptAIActual = null;

    /// <summary>
    /// Referencia al componente NavMeshAgent del enemigo detectado actualmente.
    /// </summary>
    private NavMeshAgent agentActual = null;

    /// <summary>
    /// Referencia al componente Animator del enemigo detectado actualmente.
    /// </summary>
    private Animator animatorActual = null;

    /// <summary>
    /// Actualiza el estado del enemigo detectado por un raycast cada frame.
    /// </summary>
    void Update()
    {
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayo, out hit, distancia))
        {
            if (hit.collider.CompareTag(tagEnemigo))
            {
                Component compAI = hit.collider.GetComponent(nombreScriptAI);
                NavMeshAgent agent = hit.collider.GetComponent<NavMeshAgent>();
                Animator animator = hit.collider.GetComponent<Animator>();

                if (compAI != null && agent != null && animator != null)
                {
                    if (scriptAIActual != (MonoBehaviour)compAI || agentActual != agent || animatorActual != animator)
                    {
                        RestaurarEnemigo();
                        scriptAIActual = (MonoBehaviour)compAI;
                        agentActual = agent;
                        animatorActual = animator;
                    }

                    if (scriptAIActual.enabled)
                        scriptAIActual.enabled = false;

                    if (agentActual.isActiveAndEnabled && !agentActual.isStopped)
                        agentActual.isStopped = true;

                    if (animatorActual.speed != 0)
                        animatorActual.speed = 0;
                }
            }
            else
            {
                RestaurarEnemigo();
            }
        }
        else
        {
            RestaurarEnemigo();
        }
    }

    /// <summary>
    /// Restaura el estado del enemigo previamente detenido, reactivando su IA, movimiento y animación.
    /// </summary>
    void RestaurarEnemigo()
    {
        if (scriptAIActual != null && !scriptAIActual.enabled)
        {
            scriptAIActual.enabled = true;
        }
        if (agentActual != null && agentActual.isStopped)
        {
            agentActual.isStopped = false;
        }
        if (animatorActual != null && animatorActual.speed == 0)
        {
            animatorActual.speed = 1;
        }

        scriptAIActual = null;
        agentActual = null;
        animatorActual = null;
    }
}
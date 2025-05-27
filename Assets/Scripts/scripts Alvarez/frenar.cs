using UnityEngine;
using UnityEngine.AI;

public class MirarParaEnemigo : MonoBehaviour
{
    public float distancia = 15f;
    public string tagEnemigo = "Enemigo";
    public string nombreScriptAI = "EnemyAI";

    private MonoBehaviour scriptAIActual = null;
    private NavMeshAgent agentActual = null;
    private Animator animatorActual = null;

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

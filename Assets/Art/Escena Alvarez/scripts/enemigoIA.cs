using UnityEngine;
using UnityEngine.AI;

public class enemigoIA : MonoBehaviour
{
    public float rangoVision = 10f;
    public float anguloVision = 60f;
    public float radioMerodeo = 10f;
    public float tiempoMerodeo = 5f;
    public LayerMask capaObstaculos;

    private NavMeshAgent agente;
    private Transform jugador;
    private float tiempo;
    private Animator animador;

    private enum Estado { Idle, Merodeando, Persiguiendo }
    private Estado estadoActual = Estado.Idle;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        animador = GetComponent<Animator>();
        tiempo = tiempoMerodeo;
    }

    private void Update()
    {
        tiempo += Time.deltaTime;

        if (PuedeVerJugador())
        {
            agente.SetDestination(jugador.position);
            CambiarEstado(Estado.Persiguiendo);
        }
        else
        {
            if (tiempo >= tiempoMerodeo)
            {
                Vector3 nuevaPos = PosicionAleatoria(transform.position, radioMerodeo, -1);
                agente.SetDestination(nuevaPos);
                tiempo = 0;
                CambiarEstado(Estado.Merodeando);
            }
            else if (!agente.hasPath || agente.remainingDistance < 0.5f)
            {
                CambiarEstado(Estado.Idle);
            }
        }
    }

    bool PuedeVerJugador()
    {
        Vector3 direccion = jugador.position - transform.position;
        float angulo = Vector3.Angle(transform.forward, direccion);

        if (direccion.magnitude < rangoVision && angulo < anguloVision / 2f)
        {
            if (!Physics.Raycast(transform.position + Vector3.up, direccion.normalized, direccion.magnitude, capaObstaculos))
            {
                return true;
            }
        }
        return false;
    }

    public static Vector3 PosicionAleatoria(Vector3 origen, float distancia, int capa)
    {
        Vector3 direccionAleatoria = Random.insideUnitSphere * distancia;
        direccionAleatoria += origen;

        NavMeshHit hit;
        NavMesh.SamplePosition(direccionAleatoria, out hit, distancia, capa);

        return hit.position;
    }

    void CambiarEstado(Estado nuevoEstado)
    {
        if (estadoActual == nuevoEstado) return;

        estadoActual = nuevoEstado;

        switch (estadoActual)
        {
            case Estado.Idle:
                animador.SetTrigger("Idle");
                break;
            case Estado.Merodeando:
                animador.SetTrigger("Walk");
                break;
            case Estado.Persiguiendo:
                animador.SetTrigger("Sprint");
                break;
        }
    }
}

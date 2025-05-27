using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla el comportamiento de una inteligencia artificial enemiga que patrulla, persigue al jugador y activa un jumpscare.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// Componente NavMeshAgent que controla el movimiento de la IA.
    /// </summary>
    public NavMeshAgent ai;

    /// <summary>
    /// Lista de destinos a los que la IA puede dirigirse mientras patrulla.
    /// </summary>
    public List<Transform> destinations;

    /// <summary>
    /// Componente Animator que controla las animaciones de la IA.
    /// </summary>
    public Animator aiAnim;

    /// <summary>
    /// Velocidad de movimiento de la IA al patrullar.
    /// </summary>
    public float walkSpeed;

    /// <summary>
    /// Velocidad de movimiento de la IA al perseguir al jugador.
    /// </summary>
    public float chaseSpeed;

    /// <summary>
    /// Tiempo mínimo que la IA permanece en estado inactivo.
    /// </summary>
    public float minIdleTime;

    /// <summary>
    /// Tiempo máximo que la IA permanece en estado inactivo.
    /// </summary>
    public float maxIdleTime;

    /// <summary>
    /// Tiempo actual que la IA permanecerá en estado inactivo.
    /// </summary>
    public float idleTime;

    /// <summary>
    /// Distancia máxima a la que la IA puede detectar al jugador.
    /// </summary>
    public float sightDistance;

    /// <summary>
    /// Distancia a la que la IA atrapa al jugador y activa el jumpscare.
    /// </summary>
    public float catchDistance;

    /// <summary>
    /// Tiempo actual de persecución antes de que la IA regrese a patrullar.
    /// </summary>
    public float chaseTime;

    /// <summary>
    /// Tiempo mínimo de persecución antes de que la IA regrese a patrullar.
    /// </summary>
    public float minChaseTime;

    /// <summary>
    /// Tiempo máximo de persecución antes de que la IA regrese a patrullar.
    /// </summary>
    public float maxChaseTime;

    /// <summary>
    /// Duración de la animación de jumpscare antes de cargar la escena de muerte.
    /// </summary>
    public float jumpscareTime;

    /// <summary>
    /// Indica si la IA está patrullando.
    /// </summary>
    public bool walking;

    /// <summary>
    /// Indica si la IA está persiguiendo al jugador.
    /// </summary>
    public bool chasing;

    /// <summary>
    /// Transform del jugador que la IA detecta y persigue.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Destino actual hacia el que se dirige la IA.
    /// </summary>
    Transform currentDest;

    /// <summary>
    /// Posición del destino actual de la IA.
    /// </summary>
    Vector3 dest;

    /// <summary>
    /// Índice aleatorio para seleccionar un destino de la lista.
    /// </summary>
    int randNum;

    /// <summary>
    /// Cantidad de destinos disponibles para la IA.
    /// </summary>
    public int destinationAmount;

    /// <summary>
    /// Desplazamiento para el origen del raycast de detección.
    /// </summary>
    public Vector3 rayCastOffset;

    /// <summary>
    /// Nombre de la escena que se carga tras el jumpscare.
    /// </summary>
    public string deathScene;

    /// <summary>
    /// Inicializa el estado de la IA y selecciona un destino inicial.
    /// </summary>
    void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    /// <summary>
    /// Actualiza el comportamiento de la IA cada frame, manejando detección, persecución y patrullaje.
    /// </summary>
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
        if (chasing == true)
        {
            dest = player.position;
            ai.destination = dest;
            ai.speed = chaseSpeed;
            aiAnim.ResetTrigger("walk");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("sprint");
            float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                player.gameObject.SetActive(false);
                aiAnim.ResetTrigger("walk");
                aiAnim.ResetTrigger("idle");
                aiAnim.ResetTrigger("sprint");
                aiAnim.SetTrigger("jumpscare");
                StartCoroutine(deathRoutine());
                chasing = false;
            }
        }
        if (walking == true)
        {
            dest = currentDest.position;
            ai.destination = dest;
            ai.speed = walkSpeed;
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("idle");
            aiAnim.SetTrigger("walk");
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                aiAnim.ResetTrigger("sprint");
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                ai.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }

    /// <summary>
    /// Mantiene a la IA en estado inactivo durante un tiempo aleatorio antes de continuar patrullando.
    /// </summary>
    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    ///-nit
    /// <summary>
    /// Controla la duración de la persecución antes de que la IA regrese a patrullar.
    /// </summary>
    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    /// <summary>
    /// Carga la escena de muerte tras la animación de jumpscare.
    /// </summary>
    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}
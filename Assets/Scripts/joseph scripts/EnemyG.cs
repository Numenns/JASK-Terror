using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla el comportamiento de un enemigo que patrulla entre destinos, persigue al jugador cuando lo detecta
/// y ejecuta una animación de jumpscare al atraparlo.
/// </summary>
public class EnemyG : MonoBehaviour
{
    /// <summary>
    /// Agente de navegación utilizado para mover al enemigo a través del NavMesh.
    /// </summary>
    public NavMeshAgent ai;

    /// <summary>
    /// Lista de destinos que el enemigo patrullará aleatoriamente.
    /// </summary>
    public List<Transform> destinations;

    /// <summary>
    /// Controlador de animaciones del enemigo.
    /// </summary>
    public Animator aiAnim;

    /// <summary>
    /// Velocidad de movimiento durante la patrulla.
    /// </summary>
    public float walkSpeed;

    /// <summary>
    /// Velocidad de movimiento durante la persecución.
    /// </summary>
    public float chaseSpeed;

    /// <summary>
    /// Tiempo mínimo que el enemigo permanecerá en estado de reposo.
    /// </summary>
    public float minIdleTime;

    /// <summary>
    /// Tiempo máximo que el enemigo permanecerá en estado de reposo.
    /// </summary>
    public float maxIdleTime;

    /// <summary>
    /// Tiempo actual que el enemigo permanecerá en estado de reposo.
    /// </summary>
    public float idleTime;

    /// <summary>
    /// Distancia a la cual el enemigo captura al jugador.
    /// </summary>
    public float catchDistance;

    /// <summary>
    /// Tiempo que el enemigo perseguirá al jugador antes de regresar a patrullar.
    /// </summary>
    public float chaseTime;

    /// <summary>
    /// Tiempo mínimo que el enemigo perseguirá al jugador.
    /// </summary>
    public float minChaseTime;

    /// <summary>
    /// Tiempo máximo que el enemigo perseguirá al jugador.
    /// </summary>
    public float maxChaseTime;

    /// <summary>
    /// Tiempo que dura la animación de jumpscare antes de cambiar de escena.
    /// </summary>
    public float jumpscareTime;

    /// <summary>
    /// Indica si el enemigo está patrullando.
    /// </summary>
    public bool walking;

    /// <summary>
    /// Indica si el enemigo está persiguiendo al jugador.
    /// </summary>
    public bool chasing;

    /// <summary>
    /// Referencia al transform del jugador.
    /// </summary>
    public Transform player;

    private Transform currentDest;
    private Vector3 dest;
    private int randNum;

    /// <summary>
    /// Cantidad de destinos disponibles para la patrulla.
    /// </summary>
    public int destinationAmount;

    /// <summary>
    /// Desplazamiento aplicado al origen del raycast para detectar al jugador.
    /// </summary>
    public Vector3 rayCastOffset;

    /// <summary>
    /// Nombre de la escena a cargar cuando el jugador es atrapado.
    /// </summary>
    public string deathScene;

    private float sightDistance = 2f;

    /// <summary>
    /// Inicializa el comportamiento del enemigo y comienza la rutina de cambio de distancia de visión.
    /// </summary>
    private void Start()
    {
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];

        StartCoroutine(ChangeSightDistance());
    }

    /// <summary>
    /// Actualiza el estado del enemigo cada frame, manejando la patrulla, detección y persecución del jugador.
    /// </summary>
    private void Update()
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

        if (chasing)
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

        if (walking)
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
    /// Rutina que mantiene al enemigo en estado de reposo por un tiempo aleatorio antes de continuar patrullando.
    /// </summary>
    private IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    /// <summary>
    /// Rutina que maneja el tiempo que el enemigo persigue al jugador antes de regresar a patrullar.
    /// </summary>
    private IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    /// <summary>
    /// Rutina que espera un tiempo determinado antes de cargar la escena de muerte tras un jumpscare.
    /// </summary>
    private IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }

    /// <summary>
    /// Rutina que alterna la distancia de visión del enemigo entre dos valores en intervalos de tiempo.
    /// </summary>
    private IEnumerator ChangeSightDistance()
    {
        while (true)
        {
            sightDistance = 1f;
            Debug.Log("Cambio a 1");
            yield return new WaitForSeconds(18f);

            sightDistance = 6f;
            Debug.Log("Cambio a 6");
            yield return new WaitForSeconds(7f);
        }
    }
}

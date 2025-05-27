using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla el comportamiento de un enemigo que detecta y persigue al jugador.
/// Si el jugador se acerca demasiado, se reinicia la escena.
/// </summary>
public class Enemigo : MonoBehaviour
{
    /// <summary>
    /// Referencia al transform del jugador.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Componente Animator para reproducir animaciones del enemigo.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Distancia máxima a la que el enemigo puede detectar al jugador.
    /// </summary>
    public float detectionRange = 20f;

    /// <summary>
    /// Distancia a la que el enemigo comienza a mostrar advertencia ("Cuidado").
    /// </summary>
    public float chaseRange = 5f;

    /// <summary>
    /// Velocidad de movimiento del enemigo.
    /// </summary>
    public float speed = 2f;

    /// <summary>
    /// Velocidad con la que el enemigo rota hacia el jugador.
    /// </summary>
    public float rotationSpeed = 5f;

    /// <summary>
    /// Objeto visual (UI o GameObject) que se activa como advertencia cuando el enemigo se acerca.
    /// </summary>
    public GameObject Cuidado;

    /// <summary>
    /// Indica si el enemigo está actualmente persiguiendo al jugador.
    /// </summary>
    private bool isChasing = false;

    /// <summary>
    /// Se llama cada frame. Controla la detección, persecución y colisión del enemigo con el jugador.
    /// </summary>
    void Update()
    {
        
        if (player == null) return;

       
        float distance = Vector3.Distance(transform.position, player.position);

     
        if (distance <= detectionRange)
        {
            isChasing = true;

        
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            
            transform.position += direction * speed * Time.deltaTime;

           
            if (distance <= chaseRange)
            {
                animator.speed = 0.5f;
                animator.Play("CC_Base_Body");
                Cuidado.SetActive(true);
            }
            else
            {
                animator.speed = 0f;
                Cuidado.SetActive(false);
            }

          
            if (distance <= 1f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            
            isChasing = false;
            animator.speed = 0f;
            Cuidado.SetActive(false);
        }
    }
}
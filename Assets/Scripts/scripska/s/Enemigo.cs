using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    public Transform player;                  
    public Animator animator;               
    public float detectionRange = 20f;      
    public float chaseRange = 5f;           
    public float speed = 2f;         
    public float rotationSpeed = 5f;        
    public GameObject Cuidado;                

    private bool isChasing = false;

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
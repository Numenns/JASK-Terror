using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public float detectionRange = 20f;
    public float speed = 2f;
    public GameObject emergenciaUI;
    private bool isChasing = false;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            isChasing = true;
            animator.speed = 1.5f;
            animator.Play("CC_Base_Body");
            emergenciaUI.SetActive(true);

            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            isChasing = false;
            animator.speed = 0f;
            emergenciaUI.SetActive(false);
        }
    }
}

using UnityEngine;

public class HistoriaClinica : MonoBehaviour
{
    private Animator animator;
    private bool yaDestruyendose = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Falta el componente Animator en " + gameObject.name);
        }
    }

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

    public void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}
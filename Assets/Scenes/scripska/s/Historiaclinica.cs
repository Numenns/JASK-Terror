using UnityEngine;

public class Historiaclinica : MonoBehaviour
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

        void OnTriggerEnter(Collider other)
        {
            if (!yaDestruyendose && other.CompareTag("Player"))
            {
                if (gameObject.CompareTag("HistoriaClinica") && gameObject.layer == LayerMask.NameToLayer("HistoriaClin"))
                {
                    yaDestruyendose = true;
                    animator.SetTrigger("Destruir");
                }
            }

        }
    }

         public void DestruirObjeto()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

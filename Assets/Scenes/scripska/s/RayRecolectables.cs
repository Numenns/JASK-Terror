using UnityEngine;

public class RecolectorHistoriaClinica : MonoBehaviour
{
    public float distanciaInteraccion = 3f;
    public LayerMask capaHistoriaClinica;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaInteraccion, capaHistoriaClinica))
            {
                if (hit.collider.CompareTag("HistoriaClinica"))
                {
                    Animator anim = hit.collider.GetComponent<Animator>();
                    if (anim != null)
                    {
                        anim.SetTrigger("Destruir");
                    }
                }
            }
        }
    }
}
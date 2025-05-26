using UnityEngine;
using System.Collections;

public class Transformacion : MonoBehaviour
{
    public float distanciaInteraccion = 3f;
    public LayerMask capaMedicina;

    private Vector3 escalaOriginal;
    private bool estaCreciendo = false;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaInteraccion, capaMedicina))
            {
                GameObject objeto = hit.collider.gameObject;
                if (objeto.CompareTag("Medicine"))
                {
                    Destroy(objeto);
                    if (!estaCreciendo)
                    {
                        StartCoroutine(AgrandarTemporalmente());
                    }
                }
            }
        }
    }

    private IEnumerator AgrandarTemporalmente()
    {
        estaCreciendo = true;
        transform.localScale = escalaOriginal * 2f; 

        yield return new WaitForSeconds(10f);

        transform.localScale = escalaOriginal; 
        estaCreciendo = false;
    }
}
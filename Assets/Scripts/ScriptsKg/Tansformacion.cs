using UnityEngine;
using System.Collections;

public class Transformacion : MonoBehaviour
{
    public float distanciaInteraccion = 1.5f;
    public LayerMask capaMedicina;

    private Vector3 escalaOriginal;
    private bool estaCreciendo = false;
    private GameObject tranformaA;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.forward * distanciaInteraccion, Color.red);

        if (Input.GetKeyDown(KeyCode.Q) && !estaCreciendo)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaInteraccion, capaMedicina))
            {
                if (hit.collider.CompareTag("Medicine"))
                {
                    Debug.Log("¡Medicina detectada!");
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(AgrandarTemporalmente()); 
                }
            }
            else
            {
                Debug.Log("NO SE ENCUENTRA, POSICION.");
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
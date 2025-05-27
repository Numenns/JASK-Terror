using UnityEngine;
using System.Collections;

public class Transformacion : MonoBehaviour
{
    public float distanciaInteraccion = 1.5f;
    public LayerMask capaMedicina;

    private Vector3 escalaOriginal;
    private bool estaCreciendo = false;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        // Visualiza el rayo en la escena
        Debug.DrawRay(transform.position, transform.forward * distanciaInteraccion, Color.red);

        if (Input.GetKeyDown(KeyCode.Q) && !estaCreciendo)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Lanza el ray solo contra objetos en la capa específica
            if (Physics.Raycast(ray, out hit, distanciaInteraccion, capaMedicina))
            {
                if (hit.collider.CompareTag("Medicine"))
                {
                    Debug.Log("¡Medicina detectada!");
                    Destroy(hit.collider.gameObject); // Destruye la medicina
                    StartCoroutine(AgrandarTemporalmente()); // Comienza la transformación
                }
            }
            else
            {
                Debug.Log("No se detectó nada.");
            }
        }
    }

    private IEnumerator AgrandarTemporalmente()
    {
        estaCreciendo = true;
        transform.localScale = escalaOriginal * 2f;

        yield return new WaitForSeconds(10f); // Tiempo en estado gigante

        transform.localScale = escalaOriginal;
        estaCreciendo = false;
    }
}

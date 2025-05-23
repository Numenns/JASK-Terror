using UnityEngine;
using UnityEngine.UI;

public class RaycastSeleccionador : MonoBehaviour
{
    public Camera camaraPrincipal;
    public Text dialogText;
    public string mensaje = "¡Objeto destruido!";
    public string tagObjetivo = "Historiaclinica";

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = camaraPrincipal.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objeto = hit.collider.gameObject;

                if (objeto.CompareTag(tagObjetivo) && hit.collider.isTrigger)
                {
                    MostrarDialogo(mensaje);

                    DestruccionConAnimacion animacion = objeto.GetComponent<DestruccionConAnimacion>();
                    if (animacion != null)
                    {
                        animacion.EjecutarAnimacion();
                    }
                    else
                    {
                        Destroy(objeto); 
                    }
                }
            }
        }
    }

    void MostrarDialogo(string mensaje)
    {
        if (dialogText != null)
        {
            dialogText.text = mensaje;
            dialogText.gameObject.SetActive(true);
            Invoke("OcultarDialogo", 2f);
        }
    }

    void OcultarDialogo()
    {
        if (dialogText != null)
            dialogText.gameObject.SetActive(false);
    }
}

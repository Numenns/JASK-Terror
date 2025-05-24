using UnityEngine;

public class Select : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;

    void Start()
    {
        mask = LayerMask.GetMask("rayd");
        TextDetect.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselect();
            SelectedObject(hit.transform);

            if (hit.collider.CompareTag("obji"))
            {
                // Mostrar mensaje si es un ObjNote disponible
                ObjNote nota = hit.collider.GetComponent<ObjNote>();
                if (nota != null && nota.EstaDisponible())
                {
                    nota.MostrarMensaje();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // ObjetoInteractivo
                    ObjetoInteractivo objeto = hit.collider.GetComponent<ObjetoInteractivo>();
                    if (objeto != null)
                    {
                        objeto.ActivarObjeto();
                    }
                    else
                    {
                        // ObjetoInteractivol
                        ObjetoInteractivol objetoL = hit.collider.GetComponent<ObjetoInteractivol>();
                        if (objetoL != null)
                        {
                            objetoL.ActivarObjeto();
                        }
                        else
                        {
                            // ObjNote
                            if (nota != null)
                            {
                                nota.ActivarObjeto();
                            }
                        }
                    }
                }

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
            }
            else
            {
                Deselect();
            }
        }
        else
        {
            Deselect();
        }
    }

    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    void Deselect()
    {
        if (ultimoReconocido)
        {
            // Oculta mensaje de ObjNote si corresponde
            ObjNote nota = ultimoReconocido.GetComponent<ObjNote>();
            if (nota != null)
            {
                nota.OcultarMensaje();
            }

            // Restaurar color
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        if (ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }
}

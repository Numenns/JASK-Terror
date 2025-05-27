using UnityEngine;

/// <summary>
/// Clase que gestiona la selección e interacción con objetos mediante raycast en Unity.
/// </summary>
public class Select : MonoBehaviour
{
    /// <summary>
    /// Capa utilizada para filtrar los objetos detectables por el raycast.
    /// </summary>
    LayerMask mask;

    /// <summary>
    /// Distancia máxima que alcanza el raycast desde el objeto actual.
    /// </summary>
    public float distancia = 1.5f;

    /// <summary>
    /// Textura que representa el puntero utilizado en la interfaz.
    /// </summary>
    public Texture2D puntero;

    /// <summary>
    /// Referencia al objeto de texto que muestra si algo es detectable.
    /// </summary>
    public GameObject TextDetect;

    /// <summary>
    /// Referencia al último objeto reconocido por el raycast.
    /// </summary>
    GameObject ultimoReconocido = null;

    /// <summary>
    /// Inicializa los componentes, como la máscara de raycast y desactiva el texto de detección.
    /// </summary>
    void Start()
    {
        mask = LayerMask.GetMask("rayd");
        TextDetect.SetActive(false);
    }

    /// <summary>
    /// Lanza un raycast hacia adelante para detectar objetos interactivos y gestiona su interacción.
    /// </summary>
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

    /// <summary>
    /// Cambia el color del objeto seleccionado y lo almacena como el último reconocido.
    /// </summary>
    /// <param name="transform">Transform del objeto seleccionado.</param>
    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    /// <summary>
    /// Restaura el color del último objeto reconocido y oculta su mensaje si es necesario.
    /// </summary>
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

    /// <summary>
    /// Dibuja el puntero en la interfaz gráfica y muestra el texto de detección si hay un objeto reconocido.
    /// </summary>
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

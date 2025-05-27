using UnityEngine;

/// <summary>
/// Permite la selección de objetos y la interacción mediante raycasting.
/// </summary>
public class Select2 : MonoBehaviour
{
    /// <summary>
    /// Máscara de capas utilizada para filtrar los objetos detectados por el raycast.
    /// </summary>
    LayerMask mask;

    /// <summary>
    /// Distancia máxima del raycast para detectar objetos.
    /// </summary>
    public float distancia = 1.5f;

    /// <summary>
    /// Textura utilizada como puntero en el centro de la pantalla.
    /// </summary>
    public Texture2D puntero;

    /// <summary>
    /// Objeto de texto que se activa cuando se detecta un objeto interactivo.
    /// </summary>
    public GameObject TextDetect;

    /// <summary>
    /// Último objeto detectado por el raycast.
    /// </summary>
    GameObject ultimoReconocido = null;

    /// <summary>
    /// Inicializa la máscara de capas y desactiva el texto de detección.
    /// </summary>
    void Start()
    {
        mask = LayerMask.GetMask("rayd");
        TextDetect.SetActive(false);
    }

    /// <summary>
    /// Actualiza la detección de objetos mediante raycast y maneja interacciones.
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
                ObjNote nota = hit.collider.GetComponent<ObjNote>();
                if (nota != null && nota.EstaDisponible())
                {
                    nota.MostrarMensaje();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    objInteractivo objCaja = hit.collider.GetComponent<objInteractivo>();
                    if (objCaja != null)
                    {
                        objCaja.ActivarObjeto();
                    }
                    else
                    {
                        ObjetoInteractivo objeto = hit.collider.GetComponent<ObjetoInteractivo>();
                        if (objeto != null)
                        {
                            objeto.ActivarObjeto();
                        }
                        else
                        {
                            ObjetoInteractivol objetoL = hit.collider.GetComponent<ObjetoInteractivol>();
                            if (objetoL != null)
                            {
                                objetoL.ActivarObjeto();
                            }
                            else
                            {
                                if (nota != null)
                                {
                                    nota.ActivarObjeto();
                                }
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
    /// Cambia el color del objeto detectado para indicar que está seleccionado.
    /// </summary>
    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    /// <summary>
    /// Restaura el color del último objeto detectado y oculta mensajes si es necesario.
    /// </summary>
    void Deselect()
    {
        if (ultimoReconocido)
        {
            ObjNote nota = ultimoReconocido.GetComponent<ObjNote>();
            if (nota != null)
            {
                nota.OcultarMensaje();
            }

            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

    /// <summary>
    /// Dibuja el puntero en pantalla y controla la visibilidad del texto de detección.
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
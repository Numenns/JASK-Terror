using NUnit.Framework.Constraints;
using System;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Permite manipular objetos con el mouse en el juego: moverlos, rotarlos y cambiar su escala.
/// Incluye controles para hacerlos más grandes, más pequeños o girarlos.
/// </summary>
public class agarrar : MonoBehaviour
{
    /// <summary>
    /// Offset entre el objeto y el mouse para un movimiento más natural.
    /// </summary>
    Vector3 mOffset;
    /// <summary>
    /// Profundidad del objeto respecto a la cámara en coordenadas de pantalla.
    /// </summary>
    float coordZ;
    /// <summary>
    /// Referencia al Rigidbody del objeto para controlar la gravedad.
    /// </summary>
    private Rigidbody rb;
    /// <summary>
    /// variable que indica si el objeto está en su tamaño pequeño.
    /// </summary>
    private Boolean pequeño = true;
    /// <summary>
    /// variable que indica si el objeto está en su tamaño grande.
    /// </summary>
    private Boolean grande = true;
    /// <summary>
    /// variables que indican la escala del objeto.
    /// </summary>
    private double nX;
    private double nY;
    private double nZ;
    /// <summary>
    /// Nueva escala para el tamaño grande.
    /// </summary>
    Vector3 newScaleG;
    /// <summary>
    /// Nueva escala para el tamaño pequeño.
    /// </summary>
    Vector3 newScaleP;
    /// <summary>
    /// Factor de escala aplicado al objeto.
    /// </summary>
    [SerializeField] private float escala;
    /// <summary>
    /// Cantidad de rotación aplicada al objeto al presionar 'R'.
    /// </summary>
    [SerializeField] private Vector3 rotacion;
    /// <summary>
    /// Inicializa las referencias y calcula las escalas posibles.
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nX = gameObject.transform.localScale.x * escala;
        nY = gameObject.transform.localScale.y * escala;
        nZ = gameObject.transform.localScale.z * escala;
        newScaleG = transform.localScale + new Vector3((float)nX, (float)nY, (float)nZ);
        newScaleP = transform.localScale - new Vector3((float)nX, (float)nY, (float)nZ);
        

    }
    private void Update()
    {
        
    }
    /// <summary>
    /// Controla las interacciones del mouse con el objeto:
    /// - Arrastrar con el mouse.
    /// - Alejar/Acercar con la rueda.
    /// - Rotar con la tecla 'R'.
    /// - Cambiar de tamaño con 'Q' y 'E'.
    /// </summary>
    private void OnMouseDrag()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        coordZ += scroll;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotacionActual = transform.rotation.eulerAngles;
            Vector3 nuevaRotacion = rotacionActual + rotacion;
            transform.rotation = Quaternion.Euler(nuevaRotacion);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (grande == true)
            {
                transform.localScale = newScaleG;
                pequeño = true;
                grande = false;


            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (pequeño == true)
            {
                transform.localScale = newScaleP;
                pequeño = false;
                grande = true;

            }
        }
        transform.position = getMposition() - mOffset;
    }
    /// <summary>
    /// Se ejecuta cuando se hace clic sobre el objeto. Desactiva la gravedad.
    /// </summary>
    private void OnMouseDown()
    {
        if (rb && rb.useGravity)
        {
            rb.useGravity = false;
        }
        coordZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;


    }
    /// <summary>
    /// Se ejecuta al soltar el objeto con el mouse. Reactiva la gravedad.
    /// </summary>
    private void OnMouseUp()
    {
        if (rb && !rb.useGravity)
        {
            rb.useGravity = true;
        }
    }
    /// <summary>
    /// Convierte la posición del mouse en pantalla a una posición en el mundo 3D.
    /// </summary>
    /// <returns>La posición en el mundo 3D donde se encuentra el mouse.</returns>
    private Vector3 getMposition()
    {
        Vector3 mouseP = Input.mousePosition;
        mouseP.z = coordZ;
        return Camera.main.ScreenToWorldPoint(mouseP);
    }
    
}

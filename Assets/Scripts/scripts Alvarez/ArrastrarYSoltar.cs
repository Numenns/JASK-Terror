using UnityEngine;

/// <summary>
/// Permite arrastrar y soltar un objeto en la escena utilizando el ratón.
/// </summary>
public class ArrastrarYSoltar : MonoBehaviour
{
    /// <summary>
    /// Desplazamiento entre la posición del ratón y la posición del objeto.
    /// </summary>
    Vector3 mOffset;

    /// <summary>
    /// Coordenada Z en el espacio de la pantalla para calcular la posición del ratón.
    /// </summary>
    float coordZ;

    /// <summary>
    /// Componente Rigidbody del objeto para controlar la gravedad.
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// Inicializa el componente Rigidbody del objeto.
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Actualiza la posición del objeto mientras se arrastra con el ratón.
    /// </summary>
    private void OnMouseDrag()
    {
        transform.position = getMposition() - mOffset;
    }

    /// <summary>
    /// Calcula el desplazamiento inicial y desactiva la gravedad al iniciar el arrastre.
    /// </summary>
    private void OnMouseDown()
    {
        if (rb && rb.useGravity)
        {
            rb.useGravity = false;
        }
        coordZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - getMposition();
    }

    /// <summary>
    /// Reactiva la gravedad al soltar el objeto.
    /// </summary>
    private void OnMouseUp()
    {
        if (rb && !rb.useGravity)
        {
            rb.useGravity = true;
        }
    }

    /// <summary>
    /// Obtiene la posición del ratón en el espacio del mundo.
    /// </summary>
    private Vector3 getMposition()
    {
        Vector3 mouseP = Input.mousePosition;
        mouseP.z = coordZ;
        return Camera.main.ScreenToWorldPoint(mouseP);
    }
}
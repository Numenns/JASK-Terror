using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Clase que controla el comportamiento de un objeto interactivo en el juego.
/// realiza una accion cuando el objeto coliciona, cumpliendo con los parametros de tamaño y rotacion,
/// incrementando un contador en el inventario y generando una nueva herramienta meramente estetica.
/// </summary>
public class contar_c : MonoBehaviour
{
    /// <summary>
    /// Prefab de la herramienta que se instanciará al cumplirse las condiciones.
    /// </summary>
    public GameObject herramienta;
    /// <summary>
    /// Factor de escala que se aplicará al objeto.
    /// </summary>
    [SerializeField] private float escala;
    private double nX;
    private double nY;
    private double nZ;
    /// <summary>
    /// Vector con la nueva escala para objetos grandes.
    /// </summary>
    Vector3 newScaleG;
    /// <summary>
    /// Vector con la nueva escala para objetos pequeños.
    /// </summary>
    Vector3 newScaleP;
    /// <summary>
    /// Ángulo de rotación base para la validación de colisiones.
    /// </summary>
    [SerializeField] private float rotacion;
    private float max;
    private float min;
    /// <summary>
    /// Nombre del objeto con el que se espera colisionar.
    /// </summary>
    [SerializeField] private String zona;
    /// <summary>
    /// si el objeto debe de ser grande o pequeño.
    /// </summary>
    [SerializeField] private Boolean grande;

    /// <summary>
    /// Inicializa las escalas y valores de rotación.
    /// </summary>
    void Start()
    {
        nX = gameObject.transform.localScale.x * escala;
        nY = gameObject.transform.localScale.y * escala;
        nZ = gameObject.transform.localScale.z * escala;
        newScaleG = transform.localScale + new Vector3((float)nX, (float)nY, (float)nZ);
        newScaleP = transform.localScale - new Vector3((float)nX, (float)nY, (float)nZ);
        max = rotacion + 1;
        min = rotacion - 1;
    }

    
    void Update()
    {
        
    }
    /// <summary>
    /// Verifica las colisiones con otros objetos y ejecuta la lógica de incremento de puntos.
    /// </summary>
    /// <param name="collision">El objeto que colisiona con este.</param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name.Equals(zona) && grande)
        {
            if (gameObject.transform.localScale == newScaleG && gameObject.transform.rotation.eulerAngles.y > min
                && gameObject.transform.rotation.eulerAngles.y < max)
            {
                Inventario.Instancia.Cuenta += 1;
                Debug.Log(Inventario.Instancia.Cuenta.ToString());
                Destroy(gameObject);
                Instantiate(herramienta, collision.gameObject.transform.position, gameObject.transform.rotation);
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (gameObject.transform.localScale == newScaleP && gameObject.transform.rotation.eulerAngles.y > min && gameObject.transform.rotation.eulerAngles.y < max)
            {
                Inventario.Instancia.Cuenta += 1;
                Debug.Log(Inventario.Instancia.Cuenta.ToString());
                Destroy(gameObject);
                Instantiate(herramienta, collision.gameObject.transform.position, gameObject.transform.rotation);
                Destroy(collision.gameObject);
            }
        }




    }

}

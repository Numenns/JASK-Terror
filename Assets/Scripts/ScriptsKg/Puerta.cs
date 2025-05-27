using UnityEngine;

/// <summary>
/// Detecta si el jugador está mirando una puerta interactiva usando un Raycast.
/// Si presiona la tecla 'E' mientras está cerca de una puerta etiquetada correctamente,
/// se activa la animación de abrir/cerrar la puerta.
/// </summary>
public class DetectorPuerta : MonoBehaviour
{
    /// <summary>
    /// Máscara de capa usada para detectar solo objetos en la capa "Rycastpuerta".
    /// </summary>
    LayerMask mask;

    /// <summary>
    /// Distancia máxima del raycast para detectar puertas.
    /// </summary>
    public float distancia = 1.5f;

    /// <summary>
    /// Inicializa la máscara de capa al comenzar el juego.
    /// </summary>
    void Start()
    {
        mask = LayerMask.GetMask("Rycastpuerta");
    }

    /// <summary>
    /// Cada frame lanza un raycast hacia adelante para detectar puertas cercanas.
    /// Si detecta una puerta válida y se presiona la tecla 'E', se activa su animación.
    /// </summary>
    void Update()
    {
        RaycastHit hit;

       
        if (Physics.Raycast(transform.position, transform.forward, out hit, distancia, mask))
        {
           
            if (hit.collider.CompareTag("ObjetoPuerta2"))
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    AnimaP puerta = hit.collider.GetComponent<AnimaP>();
                    if (puerta != null)
                    {
                       
                        puerta.TogglePuerta();
                    }
                }
            }
        }
    }
}

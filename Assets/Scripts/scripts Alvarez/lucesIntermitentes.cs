using System.Collections;
using UnityEngine;

/// <summary>
/// Controla el parpadeo intermitente de una luz en la escena.
/// </summary>
public class lucesIntermitentes : MonoBehaviour
{
    /// <summary>
    /// Velocidad a la que la luz parpadea, en segundos.
    /// </summary>
    public float velocidadParpadeo;

    /// <summary>
    /// Componente de luz que se controla para el parpadeo.
    /// </summary>
    private Light luz;

    /// <summary>
    /// Inicializa la luz y comienza el parpadeo con una velocidad aleatoria.
    /// </summary>
    void Start()
    {
        luz = GetComponent<Light>();
        StartCoroutine(Parpadeo());
        velocidadParpadeo = Random.Range(0.1f, 1f);
    }

    /// <summary>
    /// Alterna el estado de la luz de forma continua con un intervalo definido.
    /// </summary>
    IEnumerator Parpadeo()
    {
        while (true)
        {
            luz.enabled = !luz.enabled;
            yield return new WaitForSeconds(velocidadParpadeo);
        }
    }
}
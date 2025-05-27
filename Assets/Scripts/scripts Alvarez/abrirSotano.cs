using UnityEngine;

/// <summary>
/// Controla la activación/desactivación de objetos cuando otro objeto con cierto tag entra al trigger.
/// </summary>
public class abrirSotano : MonoBehaviour
{
    /// <summary>
    /// Objeto que se desactivará cuando un objeto con el tag "obji" entre al trigger.
    /// </summary>
    public GameObject objetoADesactivar;

    /// <summary>
    /// Primer objeto que se activará cuando un objeto con el tag "obji" entre al trigger.
    /// </summary>
    public GameObject objetoAActivar1;

    /// <summary>
    /// Segundo objeto que se activará cuando un objeto con el tag "obji" entre al trigger.
    /// </summary>
    public GameObject objetoAActivar2;

    /// <summary>
    /// Componente de audio que se reproducirá cuando un objeto con el tag "obji" entre al trigger.
    /// </summary>
    public AudioSource miAudio;

    /// <summary>
    /// Método que se ejecuta cuando otro objeto entra en el trigger.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entró al trigger: " + other.name);

        if (other.CompareTag("obji"))
        {
            Debug.Log("El objeto que entró tiene el tag 'obji'");
            miAudio.Play();

            if (objetoADesactivar != null)
            {
                objetoADesactivar.SetActive(false);
                Debug.Log("Objeto desactivado: " + objetoADesactivar.name);
            }

            if (objetoAActivar1 != null)
            {
                objetoAActivar1.SetActive(true);
                Debug.Log("Objeto activado: " + objetoAActivar1.name);
            }

            if (objetoAActivar2 != null)
            {
                objetoAActivar2.SetActive(true);
                Debug.Log("Objeto activado: " + objetoAActivar2.name);
            }
        }
        else
        {
            Debug.Log("El objeto NO tiene el tag 'obji', sino: " + other.tag);
        }
    }
}
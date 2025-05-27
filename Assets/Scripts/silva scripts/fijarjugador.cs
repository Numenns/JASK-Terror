using System.Collections;
using UnityEngine;
/// <summary>
/// Controla el comportamiento del juego al detectar al jugador en una zona específica.
/// - Reproduce música y sonido de respiración.
/// - Activa la interfaz del tiempo.
/// - Posiciona al jugador en un punto específico.
/// - Desactiva la gravedad y bloquea el movimiento.
/// </summary>
public class fijarjugador : MonoBehaviour
{
    /// <summary>
    /// Referencia al GameObject del enemigo.
    /// </summary>
    public GameObject muñeco;
    /// <summary>
    /// Referencia al AudioSource de la musica.
    /// </summary>
    public AudioSource musica;
    /// <summary>
    /// Referencia al AudioSource de la respiracion.
    /// </summary>
    public AudioSource respiracion;
    /// <summary>
    /// Referencia al Canvas con el temporizador.
    /// </summary>
    public Canvas tiempo;
    
    void Start()
    {

    }

    
    void Update()
    {

    }
    /// <summary>
    /// Detecta la colisión con el jugador (tag "Player") y activa una secuencia de eventos,
    /// entre ellos establecer el inicio del juego como true.
    /// </summary>
    /// <param name="other">Collider del objeto que entra en la zona.</param>
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            musica.Play();
            respiracion.Play();

            tiempo.gameObject.SetActive(true);
            Vector3 x = new Vector3(-1.828f, 2f, 0.335f);
            Inventario.Instancia.Iniciar = true;
            other.gameObject.transform.position = x;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Movement>().speed = 0;
        }
    }

}

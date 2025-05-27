using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Controla el comportamiento de perder o ganar en el juego,
/// incluyendo animaciones, efectos de luz, jumpscare y recarga de la escena.
/// </summary>
public class perderganar : MonoBehaviour
{
    /// <summary>
    /// Luz principal utilizada para efectos visuales durante las transiciones.
    /// </summary>
    public Light luz;
    /// <summary>
    /// Primera pustura del muñeco involucrado en la animación.
    /// </summary>
    public GameObject muñeco1;
    /// <summary>
    /// Segunda pustura del muñeco involucrado en la animación.
    /// </summary>
    public GameObject muñeco2;
    /// <summary>
    /// Tercera pustura del muñeco que se activa en la animación de ganar.
    /// </summary>
    public GameObject muñeco3;
    /// <summary>
    /// Muñeco con animacion jumpscare que se activa al perder.
    /// </summary>
    public GameObject jumpscare;
    /// <summary>
    /// Sonido de jumpscare reproducido al perder.
    /// </summary>
    public AudioSource jumpscareS;
    /// <summary>
    /// Control de ejecución para asegurar que la animación se ejecuta una sola vez.
    /// </summary>
    public Boolean x=true;
    /// <summary>
    /// Referencia al objeto del jugador.
    /// </summary>
    public GameObject jugador;
    /// <summary>
    /// Luz de la habitación, se activa al ganar.
    /// </summary>
    public Light luzcuarto;
    /// <summary>
    /// Objeto para el cambio de escena que se activa al ganar.
    /// </summary>
    public GameObject salida;
    /// <summary>
    /// bloque con collider para el inicio del juego.
    /// </summary>
    public GameObject comenzar;

    
    void Start()
    {
        
    }

    /// <summary>
    ///verifica condiciones de perder o ganar.
    /// </summary>
    void Update()
    {
       Perder();
    }
    /// <summary>
    /// Verifica las condiciones de perder o ganar y ejecuta la animación correspondiente.
    /// </summary>
    public void Perder()
    {
        if (Inventario.Instancia.Perdiste && x)
        {
            Debug.Log("instancia funcional");
            StartCoroutine(AnimacionP());
            x = false;
        }else if(Inventario.Instancia.Ganaste && x)
        {
            StartCoroutine(AnimacionG());
            x = false;
        }
    }
    /// <summary>
    /// Ejecuta la animación y lógica al perder, incluyendo jumpscare, desactivación de objetos y reinicio de escena.
    /// </summary>
    IEnumerator AnimacionP()
    {
        yield return new WaitForSeconds(1f);
        luz.intensity = 0;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 4000;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 0;
        }
        yield return new WaitForSeconds(1f);
        luz.intensity = 4000;
        
        muñeco1.active = false;
        muñeco2.active = false;
        float numero = UnityEngine.Random.Range(4, 6);
        yield return new WaitForSeconds(numero);
        jugador.GetComponent<Movement>().enabled = false;
        jugador.GetComponentInChildren<CinemachineCamera>().transform.rotation = Quaternion.Euler( 0, 90, 0);
        jumpscareS.Play();
        jumpscare.active = true;
        yield return new WaitForSeconds(2f);
        Inventario.Instancia.Perdiste = false;
        Inventario.Instancia.Ganaste = false;
        Inventario.Instancia.Iniciar = false;
        SceneManager.LoadScene("escenaSilva");

        StopAllCoroutines();
        
        
    }
    /// <summary>
    /// Ejecuta la animación y lógica al ganar, incluyendo efectos de luz, activación de objetos y control del jugador.
    /// </summary>
    IEnumerator AnimacionG()
    {
        yield return new WaitForSeconds(1f);
        luz.intensity = 0;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 4000;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 0;
        }
        yield return new WaitForSeconds(1f);
        luz.intensity = 4000;

        muñeco1.active = false;
        muñeco2.active = false;
        muñeco3.active = true;
        RenderSettings.fog = false;
        luzcuarto.enabled = true;
        salida.active = true;
        luz.intensity = 0;
        jugador.GetComponent<Rigidbody>().useGravity = true;
        jugador.gameObject.GetComponent<Movement>().speed = 5;
        comenzar.active = false;
        Inventario.Instancia.Perdiste = false;
        Inventario.Instancia.Ganaste = false;
        Inventario.Instancia.Iniciar = false;

        Debug.Log("ganaste");
        StopAllCoroutines();


    }
}

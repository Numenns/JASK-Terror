using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class velocidadCamara : MonoBehaviour
{
    /// <summary>
    /// Última rotación de la cámara para calcular la velocidad angular.
    /// </summary>
    private Quaternion lastRotation;
    /// <summary>
    /// Celocidad de roacion.
    /// </summary>
    public float rotationSpeed;
    /// <summary>
    /// Velocidad maxima a la que puede rotar
    /// </summary>
    public float rotacion_maxima;
    /// <summary>
    /// Luz del muñeco1.
    /// </summary>
    public Light luz;
    /// <summary>
    /// Luz de la pantalla.
    /// </summary>
    public Light luzTV;
    /// <summary>
    /// Luz del muñeco2.
    /// </summary>
    private Light luz3;
    /// <summary>
    /// Muñeco en primera postura.
    /// </summary>
    public GameObject muñeco1;
    /// <summary>
    /// Muñeco en segunda postura.
    /// </summary>
    public GameObject muñeco2;
    /// <summary>
    /// Intensidad de la luz del segundo muñeco.
    /// </summary>
    [SerializeField] float luz2P;
    /// <summary>
    /// Indica si el juego está en curso.
    /// </summary>
    private Boolean enJuego = false;
    /// <summary>
    /// Indica si el muñeco está "despierto".
    /// </summary>
    private Boolean despierto = false;
    /// <summary>
    /// Fuente de audio para la música.
    /// </summary>
    public AudioSource musica;
    /// <summary>
    /// Fuente de audio para la respiración.
    /// </summary>
    public AudioSource respiracion;
    /// <summary>
    /// Fuente de audio para los efectos de luces.
    /// </summary>
    public AudioSource luces;


    /// <summary>
    /// Inicializa el estado inicial: almacena la rotación inicial y busca la luz del segundo muñeco.
    /// </summary>
    void Start()
    {
        lastRotation = transform.rotation;
        luz3 = muñeco2.GetComponentInChildren<Light> ();
        
    }
    /// <summary>
    /// Se ejecuta en cada frame: calcula la velocidad, evalúa la pérdida y gestiona el inicio.
    /// </summary>
    void Update()
    {
        if (Inventario.Instancia.Perdiste)
        {
            StopAllCoroutines();
        }
        velocidad();
        perder();
        comenzar();
    }
    /// <summary>
    /// Calcula la velocidad de rotación de la cámara con respecto al frame anterior.
    /// </summary>
    public void velocidad()
    {
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastRotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
        if (angle > 180f)
        {
            angle = 360f - angle;
        }

        rotationSpeed = angle / Time.deltaTime;
        lastRotation = transform.rotation;
    }
    /// <summary>
    /// Evalúa si el jugador pierde por exceder la velocidad máxima permitida.
    /// </summary>
    public void perder()
    {
        if (rotationSpeed > rotacion_maxima && enJuego)
        {
            Debug.Log("perder");
            Inventario.Instancia.Perdiste = true;
            StopAllCoroutines();
        }
        else if(despierto && rotationSpeed > 3f)
        {
            Debug.Log("perder");
            StopAllCoroutines();
            Inventario.Instancia.Perdiste = true;
        }
    }
    /// <summary>
    /// Corrutina que simula el comportamiento de encendido y apagado de luces, sonidos y cambios de muñeco.
    /// </summary>
    IEnumerator revision()
    {
        musica.Play();
        respiracion.volume = 0.3f;
        Debug.Log("inicia ciclo");
        float numero = UnityEngine.Random.Range(5, 11);
        yield return new WaitForSeconds(numero);
        luz.intensity = 0;
        luces.Play();
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            luz.intensity = 4000;
            yield return new WaitForSeconds(0.1f);
            luz.intensity = 0;
        }
        yield return new WaitForSeconds(1f);
        luz.intensity = 0;
        luzTV.intensity = 0;
        muñeco1.active = false;
        muñeco2.active = true;
        luz3.intensity = luz2P;
        musica.Pause();
        respiracion.volume = 0.3f;

        despierto = true;
        

        yield return new WaitForSeconds(3.5f);
        luces.Play();
        despierto = false;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            luz3.intensity = luz2P;
            yield return new WaitForSeconds(0.1f);
            luz3.intensity = 0;
        }
        
        yield return new WaitForSeconds(1f);
        ;
        muñeco2.active = false;
        luz.intensity = 4000;
        luzTV.intensity = 66;
        muñeco1.active = true;

        StartCoroutine(revision());
    }
    /// <summary>
    /// Inicia el ciclo del juego si la variable Iniciar es true y el juego no a comenzado.
    /// </summary>
    public void comenzar()
    {
        if (Inventario.Instancia.Iniciar && enJuego == false)
        {
            Debug.Log("x");
            enJuego = true;
            StartCoroutine(revision());
        }
    } 
    
}
using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class velocidadCamara : MonoBehaviour
{

    private Quaternion lastRotation;
    public float rotationSpeed;
    public float rotacion_maxima;
    public Light luz;
    public Light luzTV;
    private Light luz3;
    public GameObject muñeco1;
    public GameObject muñeco2;
    [SerializeField] float luz2P;
    private Boolean enJuego = false;
    private Boolean despierto = false;
    public AudioSource musica;
    public AudioSource respiracion;
    public AudioSource luces;
    
    

    void Start()
    {
        lastRotation = transform.rotation;
        luz3 = muñeco2.GetComponentInChildren<Light> ();
        
    }

    void Update()
    {
        
        velocidad();
        perder();
        comenzar();
    }

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
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
    public Light luz3;
    public GameObject muñeco1;
    public GameObject muñeco2;
    [SerializeField] float luz2P;
    private Boolean inicio = false;
    private Boolean perder = false;
    void Start()
    {
        lastRotation = transform.rotation;
        
    }

    void Update()
    {
        velocidad();
        perder1();
        perder2();
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
    public void perder1()
    {
        if (rotationSpeed > rotacion_maxima && inicio)
        {
            GameManager.Instance.Perdiste = true;
        }
    }

    IEnumerator RepetirCada5Segundos()
    {
        Debug.Log("inicia ciclo");
        float numero = UnityEngine.Random.Range(5, 11);
        
        yield return new WaitForSeconds(numero);
        luz.intensity = 0;
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

        if (rotationSpeed > 5)
        {
            perder = true;
        }

        yield return new WaitForSeconds(3.5f);
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
        muñeco1.active = true;

        StartCoroutine(RepetirCada5Segundos());
    }
    public void comenzar()
    {
        if (GameManager.Instance.Iniciar && inicio == false)
        {
            inicio = true;
            StartCoroutine(RepetirCada5Segundos());
        }
    } 
    public void perder2()
    {
        if (perder)
        {
            StopAllCoroutines();
            GameManager.Instance.Perdiste = true;
        }
    }
}
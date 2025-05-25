using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class velocidadCamara : MonoBehaviour
{
    private Quaternion lastRotation;
    public float rotationSpeed;
    private float tiempo;
    public float rotacion_maxima;
    public Light luz;
    public Light luz2;
    public Light luz3;
    public GameObject muñeco1;
    public GameObject muñeco2;
    [SerializeField] float luz2P;
    public ScriptableObject x;
    void Start()
    {
        lastRotation = transform.rotation;

        StartCoroutine(RepetirCada5Segundos());
    }

    void Update()
    {
        velocidad();
        perder1();
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
        if (rotationSpeed > rotacion_maxima)
        {
            //Debug.Log("perdiste");
        }
    }

    IEnumerator RepetirCada5Segundos()
    {

        float numero = UnityEngine.Random.Range(7, 11);

        yield return new WaitForSeconds(numero);
        luz.intensity = 0;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            luz.intensity = 1000;
            yield return new WaitForSeconds(0.1f);
            luz.intensity = 0;
        }
        yield return new WaitForSeconds(0.1f);
        luz.intensity = 0;
        luz2.intensity = 0;
        muñeco1.active = false;
        muñeco2.active = true;

            luz3.intensity = luz2P;
            if (rotationSpeed > 2)
            {
                Debug.Log("xd");
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
        luz.intensity = 1000;
        luz2.intensity = 5.21f;
        muñeco2.active = false;
        muñeco1.active = true;

        StartCoroutine(RepetirCada5Segundos());
    }
}
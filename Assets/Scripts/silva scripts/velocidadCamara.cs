using JetBrains.Annotations;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class velocidadCamara : MonoBehaviour
{
    private Quaternion lastRotation;
    public float rotationSpeed;
    private int Estres;

    private float tiempoAcumulado = 0f;
    private float intervalo = 1f;

    private float tiempoQuieto = 0f;
    private float intervaloReduccion = 1f; // cada cuánto tiempo baja el estrés al estar quieto

    void Start()
    {
        lastRotation = transform.rotation;
        Cal_estres();
    }

    void Update()
    {
        // Calcular rotación
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastRotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
        if (angle > 180f)
        {
            angle = 360f - angle;
        }

        rotationSpeed = angle / Time.deltaTime;
        lastRotation = transform.rotation;

        
   
        
    }
    private void Cal_estres()
    {
            if (rotationSpeed > 0.1f)
            {
                tiempoAcumulado += Time.deltaTime;
                tiempoQuieto = 0f;

                if (tiempoAcumulado >= intervalo)
                {
                    Estres++;
                    Debug.Log("Estrés aumentado a: " + Estres);
                    tiempoAcumulado = 0f;
                }
            }
            else // Está quieto
            {
                tiempoAcumulado = 0f;
                tiempoQuieto += Time.deltaTime;

                if (tiempoQuieto >= intervaloReduccion && Estres > 0)
                {
                    Estres--;
                    Debug.Log("Estrés reducido a: " + Estres);
                    tiempoQuieto = 0f;
                }
            }
            
    }

}
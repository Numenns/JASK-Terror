using JetBrains.Annotations;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class velocidadCamara : MonoBehaviour
{
    private Quaternion lastRotation;
    public float rotationSpeed;
    private int Estres;

    public float rotacion_maxima;

    void Start()
    {
        lastRotation = transform.rotation;
    }

    void Update()
    {
        
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastRotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
        if (angle > 180f)
        {
            angle = 360f - angle;
        }

        rotationSpeed = angle / Time.deltaTime;
        lastRotation = transform.rotation;
        if (rotationSpeed > rotacion_maxima)
        {
            //Debug.Log("perdiste");
        }
        
   
        
    }
    

}
using UnityEngine;

public class velocidadCamara : MonoBehaviour
{
    private Quaternion lastRotation;
    public float rotationSpeed;

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
        Debug.Log("Velocidad de rotación: " + rotationSpeed + " grados/segundo");
    }
}

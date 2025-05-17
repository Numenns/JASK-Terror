using UnityEngine;

[RequireComponent(typeof(Light))]
public class light : MonoBehaviour
{
    public float maxRotationX = 90f; 
    public float maxIntensity = 1f;  
    public float minIntensity = 0.1f; 

    private Light spotLight;

    void Start()
    {
        spotLight = GetComponent<Light>();
    }

    void Update()
    {
        float rotationX = transform.rotation.eulerAngles.x;

     
        if (rotationX > 180) rotationX -= 360;
        rotationX = Mathf.Abs(rotationX);

       
        float t = Mathf.Clamp01(rotationX / maxRotationX);

      
        spotLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, t);
    }
}
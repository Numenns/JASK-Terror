using UnityEngine;

/// <summary>
/// Ajusta la intensidad de una luz en función de la rotación en el eje X del objeto.
/// La intensidad disminuye a medida que la rotación se aleja de la posición vertical.
/// </summary>
[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour
{
    /// <summary>
    /// Ángulo máximo de rotación en el eje X que se considera para calcular la intensidad.
    /// </summary>
    public float maxRotationX = 90f;

    /// <summary>
    /// Intensidad máxima de la luz cuando la rotación es 0.
    /// </summary>
    public float maxIntensity = 1f;

    /// <summary>
    /// Intensidad mínima de la luz cuando la rotación alcanza maxRotationX.
    /// </summary>
    public float minIntensity = 0.1f;

    private Light spotLight;

    /// <summary>
    /// Inicializa la referencia al componente Light.
    /// </summary>
    private void Start()
    {
        spotLight = GetComponent<Light>();
    }

    /// <summary>
    /// Actualiza la intensidad de la luz en cada frame según la rotación en el eje X.
    /// </summary>
    private void Update()
    {
        float rotationX = transform.rotation.eulerAngles.x;

        // Ajusta el ángulo para que esté en el rango [-180, 180]
        if (rotationX > 180) rotationX -= 360;
        rotationX = Mathf.Abs(rotationX);

        // Calcula el factor de interpolación basado en la rotación
        float t = Mathf.Clamp01(rotationX / maxRotationX);

        // Interpola la intensidad entre los valores máximos y mínimos
        spotLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, t);
    }
}

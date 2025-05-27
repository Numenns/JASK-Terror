using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gestiona la configuración del volumen de audio en el juego, utilizando un slider de UI y almacenando el valor en PlayerPrefs.
/// </summary>
public class VolumeSetting : MonoBehaviour
{
    /// <summary>
    /// Fuente de audio cuyo volumen se controla.
    /// </summary>
    public AudioSource audioSource;

    /// <summary>
    /// Slider de la interfaz de usuario para ajustar el volumen.
    /// </summary>
    public Slider slider;

    /// <summary>
    /// Clave utilizada para almacenar y recuperar el valor del volumen en PlayerPrefs.
    /// </summary>
    private const string VolumeKey = "masterVolume";

    /// <summary>
    /// Inicializa el volumen cargando el valor guardado desde PlayerPrefs o estableciendo un valor predeterminado.
    /// Vincula el evento de cambio de valor del slider al método SetVolume.
    /// </summary>
    private void Start()
    {
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumeKey);
            slider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
        else
        {
            float defaultVolume = 1f;
            slider.value = defaultVolume;
            SetVolume(defaultVolume);
        }

        slider.onValueChanged.AddListener(SetVolume);
    }

    /// <summary>
    /// Establece el volumen de la fuente de audio y guarda el valor en PlayerPrefs.
    /// </summary>
    /// <param name="value">El valor del volumen, entre 0 y 1, establecido por el slider.</param>
    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
    }
}
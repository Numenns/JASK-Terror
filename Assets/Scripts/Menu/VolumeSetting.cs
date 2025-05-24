using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    private const string VolumeKey = "masterVolume";

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

    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
    }
}

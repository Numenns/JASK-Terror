using UnityEngine;

public class audioprox : MonoBehaviour
{
    public Transform player;
    public float maxVolume = 1f;
    public float playInterval = 3f;

    private Collider zone;
    private AudioSource audioSrc;
    private float timer;

    void Start()
    {
        zone = GetComponent<Collider>();
        audioSrc = GetComponent<AudioSource>();

        if (zone == null || audioSrc == null)
        {
            Debug.LogError("Falta un Collider o AudioSource en " + gameObject.name);
            enabled = false;
            return;
        }

        audioSrc.loop = false; 
        timer = playInterval;
    }

    void Update()
    {
        if (zone.bounds.Contains(player.position))
        {
            float dist = Vector3.Distance(player.position, zone.bounds.center);
            float maxDist = zone.bounds.extents.magnitude;
            float volume = Mathf.Clamp01(1 - (dist / maxDist)) * maxVolume;

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                audioSrc.volume = volume;
                audioSrc.Play();
                timer = playInterval;
            }
        }
        else
        {
            timer = playInterval;
        }
    }
}

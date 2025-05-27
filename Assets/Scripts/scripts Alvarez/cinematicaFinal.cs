using UnityEngine;
using UnityEngine.Playables;

public class cinematicaFinal : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject personaje;
    public GameObject enemigo;
    public GameObject mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (personaje != null)
                personaje.SetActive(false);
                enemigo.SetActive(false);
                mainCamera.SetActive(false);

            director.Play(); 
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class saltodeescenatemp : MonoBehaviour
{
    public string nombreEscena;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}

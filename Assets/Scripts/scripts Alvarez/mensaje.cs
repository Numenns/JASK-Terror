using UnityEngine;

public class mensaje : MonoBehaviour
{
    public GameObject panelMensaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        panelMensaje.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensaje.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelMensaje.SetActive(false);
        }
    }
}

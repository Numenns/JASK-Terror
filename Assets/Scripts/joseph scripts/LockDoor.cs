using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public GameObject lockdoorMessage;

    // Referencia al script lightControl
    public lightControl lightController;

    private void Start()
    {
        // Puedes buscarlo automáticamente si no lo asignas en el inspector
        if (lightController == null)
        {
            lightController = FindObjectOfType<lightControl>();
        }
    }

    private void Update()
    {
        if (lightController != null && lightController.linterapick)
        {
            Destroy(gameObject); // Destruye el objeto que porta este script
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lockdoorMessage != null)
                lockdoorMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lockdoorMessage != null)
                lockdoorMessage.SetActive(false);
        }
    }
}
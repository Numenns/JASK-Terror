using UnityEngine;

public class DetectorFuego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RayRecolectables recolector = FindFirstObjectByType<RayRecolectables>();
            ;
            if (recolector != null)
            {
                recolector.ActivarGameOver();
            }
        }
    }
}
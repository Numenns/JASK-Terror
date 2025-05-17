using UnityEngine;

public class DetectorPuerta : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;

    void Start()
    {
        mask = LayerMask.GetMask("Rycastpuerta");
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distancia, mask))
        {
            if (hit.collider.CompareTag("ObjetoPuerta2"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    AnimaP puerta = hit.collider.GetComponent<AnimaP>();
                    if (puerta != null)
                    {
                        puerta.TogglePuerta();
                    }
                }
            }
        }
    }
}


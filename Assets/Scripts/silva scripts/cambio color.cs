using Unity.VisualScripting;
using UnityEngine;

public class cambiocolor : MonoBehaviour
{  
    void Start()
    {
        
    }

    void Update()
    {
        cambio();
    }
    private void cambio()
    {
        if (GameManager.Instance.f1 == true)
        {
            Destroy(gameObject);

        }
        if (GameManager.Instance.f1 == false)
        {
            Renderer renderer = GetComponent<Renderer>();
            Material material = new Material(renderer.material);
            material.color = new Color(1f, 0f, 0f, 0.3f);
            renderer.material = material;
        }
    }
}

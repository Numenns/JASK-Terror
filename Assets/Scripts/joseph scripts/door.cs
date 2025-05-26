using UnityEngine;

public class door : MonoBehaviour
{
    void Update()
    {
        if (Inventario.Instancia.Motores >= 8)
        {
            gameObject.SetActive(false);
        }
    }
}
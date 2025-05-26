using UnityEngine;

public class door : MonoBehaviour
{
    void Update()
    {
        if (Inventario.Instancia.Motores >= 1)
        {
            gameObject.SetActive(false);
        }
    }
}
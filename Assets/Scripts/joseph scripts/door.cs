using UnityEngine;

public class door : MonoBehaviour
{
    void Update()
    {
        if (Inventario.Instancia.Motores >= 6)
        {
            gameObject.SetActive(false);
        }
    }
}
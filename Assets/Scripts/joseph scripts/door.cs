using UnityEngine;

public class Door : MonoBehaviour
{
    void Update()
    {
        if (Inventario.Instancia != null && Inventario.Instancia.Motores >= 7)
        {
            gameObject.SetActive(false);
        }
    }
}
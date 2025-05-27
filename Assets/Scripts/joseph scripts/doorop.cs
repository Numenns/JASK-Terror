using UnityEngine;

public class doorop : MonoBehaviour
{
    public GameObject opdoor;

    void Update()
    {
        if (Inventario.Instancia != null && Inventario.Instancia.Motores >= 7)
        {
            opdoor.SetActive(true);
        }
    }
}
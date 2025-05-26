using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject opdoor;

    void Update()
    {
        if (Inventario.Instancia.Motores >= 8)
        {
            opdoor.SetActive(true);
        }
    }
}
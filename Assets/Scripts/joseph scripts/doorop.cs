using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject opdoor;

    void Update()
    {
        if (Inventario.Instancia.Motores >= 6)
        {
            opdoor.SetActive(true);
        }
    }
}
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject opdoor;

    void Update()
    {
        if (Inventario.Instancia.Motores >= 1)
        {
            opdoor.SetActive(true);
        }
    }
}
using UnityEngine;

public class DoorOp : MonoBehaviour
{
    public GameObject opdoor;
    private bool puertaAbierta = false;

    void Update()
    {
        if (!puertaAbierta && Inventario.Instancia != null && Inventario.Instancia.Motores >= 7)
        {
            opdoor.SetActive(true);
            puertaAbierta = true;
        }
    }
}
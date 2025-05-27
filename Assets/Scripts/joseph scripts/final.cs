using UnityEngine;

public class final : MonoBehaviour
{
    public GameObject opdoor;
    private bool puertaAbierta = false;

    void Update()
    {
        if (!puertaAbierta && Inventario.Instancia != null && Inventario.Instancia.Motores >= 9)
        {
            opdoor.SetActive(true);
            puertaAbierta = true;
        }
    }
}
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject opdoor;

    void Update()
    {
        if (gameInstance.Instance.Motores >= 1)
        {
            opdoor.SetActive(true);
        }
    }
}
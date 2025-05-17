using UnityEngine;

public class door : MonoBehaviour
{
    void Update()
    {
        if (gameInstance.Instance.Motores >= 1)
        {
            gameObject.SetActive(false);
        }
    }
}
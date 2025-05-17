using Unity.VisualScripting;
using UnityEngine;

public class cambiocolor : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        cambio();
    }
    private void cambio()
    {
        if (GameManager.Instance.Obj1 == true)
        {
            Destroy(gameObject);
        }
    }
   
}

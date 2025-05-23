using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class respawn : MonoBehaviour
{
    public GameObject herramienta;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("objeto"))
        {
            Debug.Log("callo");
            switch (other.name)
            {
                case "Obj1":
                    Debug.Log("hola mundo");
                    Vector3 x = new Vector3(-2.135f, 1.6218f, -1.0567f);
                    other.gameObject.transform.position = x;
                    break;
            }
        }
    }

}

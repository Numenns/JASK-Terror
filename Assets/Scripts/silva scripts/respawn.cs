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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="zona respawn")
        {
            switch (gameObject.name)
            {
                case "obj1":
                    
                    Vector3 x = new Vector3(-2.135f, 1.6218f, -1.0567f);
                    Quaternion R = Quaternion.Euler(-90f, 0f, 0f);
                    Instantiate(gameObject, x, R);
                    Destroy(gameObject);
                    break;
            }
        }


    }
}

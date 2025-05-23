using System;
using Unity.Mathematics;
using UnityEngine;


public class contar_c : MonoBehaviour
{
    public GameObject herramienta;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.localScale.ToString() + "rotacion" + gameObject.transform.rotation.eulerAngles.ToString());
    }
    private void OnTriggerEnter(Collider collision)
    {
        switch (gameObject.name)
        {
            case "Obj1":
                if (collision.gameObject.name.Equals("Obj1zona"))
                {
                    quaternion y = quaternion.Euler(270f, 90f, 0f);
                    if (gameObject.transform.localScale.x < 0.7f && gameObject.transform.rotation == y)
                    {
                        GameManager.Instance.Obj1 = true;
                        Debug.Log(GameManager.Instance.Obj1.ToString());
                        Destroy(gameObject);
                        Instantiate(herramienta, collision.gameObject.transform.position, gameObject.transform.rotation);
                    }


                }
                break;
            
        }
        
    }
    
}

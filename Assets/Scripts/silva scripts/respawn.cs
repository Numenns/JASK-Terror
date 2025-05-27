using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Clase responsable de reposicionar objetos con el tag "objeto" en ubicaciones específicas al colisionar con el trigger.
/// </summary>
public class respawn : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    /// <summary>
    /// Detecta colisiones con objetos que tengan el tag "objeto" y los reposiciona según su nombre.
    /// </summary>
    /// <param name="other">Collider del objeto que entra en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("objeto"))
        {
            Debug.Log("callo");
            switch (other.name)
            {
                case "Obj1":
                    Debug.Log("hola mundo");
                    Vector3 x = new Vector3(-1.119f, 1.6218f, -0.684f);
                    other.gameObject.transform.position = x;
                    break;
                case "Obj2":
                    Debug.Log("hola mundo");
                    Vector3 x2 = new Vector3(-1.126f, 1.607f, -0.993f);
                    other.gameObject.transform.position = x2;
                    break;
                case "Obj3":
                    Debug.Log("hola mundo");
                    Vector3 x3 = new Vector3(-1.443f, 1.65f, -0.987f);
                    other.gameObject.transform.position = x3;
                    break;
                case "Obj4":
                    Debug.Log("hola mundo");
                    Vector3 x4 = new Vector3(-1.457f, 1.556f, -0.795f);
                    other.gameObject.transform.position = x4;
                    break;
                case "Obj5":
                    Debug.Log("hola mundo");
                    Vector3 x5 = new Vector3(-1.447f, 1.731f, -0.677f);
                    other.gameObject.transform.position = x5;
                    break;
                case "Obj6":
                    Debug.Log("hola mundo");
                    Vector3 x6 = new Vector3(-1.889f, 1.622f, -0.828f);
                    other.gameObject.transform.position = x6;
                    break;
            }
        }
    }

}

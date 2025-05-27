using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class contar_c : MonoBehaviour
{
    public GameObject herramienta;
    [SerializeField] private float escala;
    private double nX;
    private double nY;
    private double nZ;
    Vector3 newScaleG;
    Vector3 newScaleP;
    [SerializeField] private float rotacion;
    private float max;
    private float min;
    [SerializeField] private String zona;
    [SerializeField] private Boolean grande;

    void Start()
    {
        nX = gameObject.transform.localScale.x * escala;
        nY = gameObject.transform.localScale.y * escala;
        nZ = gameObject.transform.localScale.z * escala;
        newScaleG = transform.localScale + new Vector3((float)nX, (float)nY, (float)nZ);
        newScaleP = transform.localScale - new Vector3((float)nX, (float)nY, (float)nZ);
        max = rotacion + 1;
        min = rotacion - 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.localScale.ToString() + "rotacion" + gameObject.transform.rotation.eulerAngles.ToString());
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("colicion");
        if (collision.gameObject.name.Equals(zona) && grande)
        {
            Debug.Log("colicion G");
            if (gameObject.transform.localScale == newScaleG && gameObject.transform.rotation.eulerAngles.y > min
                && gameObject.transform.rotation.eulerAngles.y < max)
            {
                Debug.Log(collision.gameObject.transform.position);
                Inventario.Instancia.Cuenta += 1;
                Debug.Log(Inventario.Instancia.Cuenta.ToString());
                Destroy(gameObject);
                Instantiate(herramienta, collision.gameObject.transform.position, gameObject.transform.rotation);
                Destroy(collision.gameObject);
            }


        }
        else
        {
            if (gameObject.transform.localScale == newScaleP && gameObject.transform.rotation.eulerAngles.y > min && gameObject.transform.rotation.eulerAngles.y < max)
            {
                Debug.Log(collision.gameObject.transform.position);
                Inventario.Instancia.Cuenta += 1;
                Debug.Log(Inventario.Instancia.Cuenta.ToString());
                Destroy(gameObject);
                Instantiate(herramienta, collision.gameObject.transform.position, gameObject.transform.rotation);
                Destroy(collision.gameObject);
            }
        }




    }

}

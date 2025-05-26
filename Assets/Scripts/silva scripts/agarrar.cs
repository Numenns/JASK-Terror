using NUnit.Framework.Constraints;
using System;
using Unity.Mathematics;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    Vector3 mOffset;
    float coordZ;
    private Rigidbody rb;
    private Boolean pequeño = true;
    private Boolean grande = true;
    private double nX;
    private double nY;
    private double nZ;
    Vector3 newScaleG;
    Vector3 newScaleP;
    [SerializeField] private float escala;
    [SerializeField] private Vector3 rotacion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nX = gameObject.transform.localScale.x * escala;
        nY = gameObject.transform.localScale.y * escala;
        nZ = gameObject.transform.localScale.z * escala;
        newScaleG = transform.localScale + new Vector3((float)nX, (float)nY, (float)nZ);
        newScaleP = transform.localScale - new Vector3((float)nX, (float)nY, (float)nZ);
        

    }
    private void Update()
    {

    }
    private void OnMouseDrag()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        coordZ += scroll;
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 rotacionActual = transform.rotation.eulerAngles;
            Vector3 nuevaRotacion = rotacionActual + rotacion;
            transform.rotation = Quaternion.Euler(nuevaRotacion);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (grande == true)
            {
                transform.localScale = newScaleG;
                pequeño = true;
                grande = false;


            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (pequeño == true)
            {
                transform.localScale = newScaleP;
                pequeño = false;
                grande = true;

            }
        }
        transform.position = getMposition() - mOffset;
    }
    private void OnMouseDown()
    {
        if (rb && rb.useGravity)
        {
            rb.useGravity = false;
        }
        coordZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //mOffset = gameObject.transform.position - getMposition();


    }
    private void OnMouseUp()
    {
        if (rb && !rb.useGravity)
        {
            rb.useGravity = true;
        }
    }
    private Vector3 getMposition()
    {
        Vector3 mouseP = Input.mousePosition;
        mouseP.z = coordZ;
        return Camera.main.ScreenToWorldPoint(mouseP);
    }
}

using System;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    Vector3 mOffset;
    float coordZ;
    private Rigidbody rb;
    private Boolean pequeño=true;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDrag()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        coordZ += scroll;
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(0, 0, 90f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 newScale = transform.localScale + new Vector3(0.2f, 0.2f, 0.2f);
            if (pequeño==true)
            {
                transform.localScale = newScale;
                pequeño = false;
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 newScale = transform.localScale - new Vector3(0.2f, 0.2f, 0.2f);
            if (pequeño == false)
            {
                transform.localScale = newScale;
                pequeño = true;
             
            }
        }
        transform.position = getMposition() - mOffset;
    }
    private void OnMouseDown()
    {
        if(rb && rb.useGravity)
        {
            rb.useGravity = false;
        }
        coordZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - getMposition();
        
    }
    private void OnMouseUp()
    {
        if(rb && !rb.useGravity)
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

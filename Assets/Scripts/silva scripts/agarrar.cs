using UnityEngine;

public class agarrar : MonoBehaviour
{
    Vector3 mOffset;
    float coordZ;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseDrag()
    {
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
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
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

using UnityEngine;

public class Movement : MonoBehaviour

{
    private float yaw = 0f, pitch = 0f;
    private Rigidbody rb;

    [SerializeField] Transform cameraHolder;
    [SerializeField] public float speed = 5f, sens = 2f;
    [SerializeField] bool bloqueoCursor = true;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(rb.transform.position, Vector3.down, 1 + 0.001f))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5f, rb.linearVelocity.z);
        }
        Look();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    private void Look()
    {
        yaw += Input.GetAxis("Mouse X") * sens;
        pitch -= Input.GetAxis("Mouse Y") * sens;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        
        transform.eulerAngles = new Vector3(0f, yaw, 0f); 
        cameraHolder.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }
    
}




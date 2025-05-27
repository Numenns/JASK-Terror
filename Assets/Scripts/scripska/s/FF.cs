using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float jumpForce = 8f;
    public float gravedad = 20f;

    public Transform camaraTransform;
    public float sensibilidadMouse = 2f;
    public float limiteVertical = 80f;

    private CharacterController controller;
    private float rotacionX = 0f;

    private Vector3 direccionMovimiento = Vector3.zero;
    private float velocidadCaida = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotarCamara();
        MoverJugador();
    }

    void RotarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        transform.Rotate(Vector3.up * mouseX);

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -limiteVertical, limiteVertical);
        camaraTransform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
    }

    void MoverJugador()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * inputX + transform.forward * inputZ;
        direccionMovimiento.x = direccion.x * velocidadMovimiento;
        direccionMovimiento.z = direccion.z * velocidadMovimiento;

        if (controller.isGrounded)
        {
            velocidadCaida = -gravedad * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                velocidadCaida = jumpForce;
            }
        }
        else
        {
            velocidadCaida -= gravedad * Time.deltaTime;
        }

        direccionMovimiento.y = velocidadCaida;

        controller.Move(direccionMovimiento * Time.deltaTime);
    }
}
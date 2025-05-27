using UnityEngine;

/// <summary>
/// Controla el movimiento del jugador en primera persona, incluyendo rotación con el mouse,
/// movimiento con teclado y salto con física básica.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class FF : MonoBehaviour
{
    /// <summary>
    /// Velocidad de movimiento del jugador en unidades por segundo.
    /// </summary>
    public float velocidadMovimiento = 5f;

    /// <summary>
    /// Fuerza aplicada al saltar.
    /// </summary>
    public float jumpForce = 8f;

    /// <summary>
    /// Aceleración de la gravedad aplicada al jugador.
    /// </summary>
    public float gravedad = 20f;

    /// <summary>
    /// Referencia al transform de la cámara para rotación vertical.
    /// </summary>
    public Transform camaraTransform;

    /// <summary>
    /// Sensibilidad del mouse para rotación.
    /// </summary>
    public float sensibilidadMouse = 2f;

    /// <summary>
    /// Límite vertical (ángulo) para rotación hacia arriba y abajo.
    /// </summary>
    public float limiteVertical = 80f;

    private CharacterController controller;
    private float rotacionX = 0f;
    private Vector3 direccionMovimiento = Vector3.zero;
    private float velocidadCaida = 0f;

    /// <summary>
    /// Inicializa componentes y configura el estado del cursor.
    /// </summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Llama a los métodos de rotación de cámara y movimiento del jugador en cada frame.
    /// </summary>
    void Update()
    {
        RotarCamara();
        MoverJugador();
    }

    /// <summary>
    /// Maneja la rotación de la cámara y del jugador usando el movimiento del mouse.
    /// </summary>
    void RotarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        
        transform.Rotate(Vector3.up * mouseX);

      
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -limiteVertical, limiteVertical);
        camaraTransform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
    }

    /// <summary>
    /// Maneja el movimiento del jugador, el salto y la aplicación de la gravedad.
    /// </summary>
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

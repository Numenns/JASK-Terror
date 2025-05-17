using UnityEngine;

public class AnimaP : MonoBehaviour
{
    public float anguloApertura = 90f;
    public float velocidadRotacion = 2f;

    private bool isOpen = false;
    private Quaternion rotacionInicial;
    private Quaternion rotacionAbierta;

    void Start()
    {
        rotacionInicial = transform.rotation;
        rotacionAbierta = Quaternion.Euler(rotacionInicial.eulerAngles + new Vector3(0, anguloApertura, 0));
    }

    public void TogglePuerta()
    {
        isOpen = !isOpen;
    }

    void Update()
    {
        Quaternion destino = isOpen ? rotacionAbierta : rotacionInicial;
        transform.rotation = Quaternion.Lerp(transform.rotation, destino, Time.deltaTime * velocidadRotacion);
    }
}

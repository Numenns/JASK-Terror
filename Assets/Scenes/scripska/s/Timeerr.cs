using TMPro;
using UnityEngine;


public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float tiempomaximo;
    private float tiempoActual;
    private bool tiempoActivado = false;
    private int minutos;
    public TextMeshProUGUI temp;

    private void Start()
    {
        ActivarTemporizador();
    }
    void Update()
    {
        if (tiempoActivado)
        {
            CambiarTimeer();
        }
        acomodarT();
        temp.text = minutos + ":" + tiempoActual;

    }

    private void CambiarTimeer()
    {
        tiempoActual += Time.deltaTime;

        if (minutos >= tiempomaximo)
        {
            Debug.Log("Derrota");
            CambiarTemporizador(false);
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempomaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
    public void acomodarT()
    {
        if (tiempoActual > 60)
        {
            minutos += 1;
            tiempoActual = 0;
        }
    }

}

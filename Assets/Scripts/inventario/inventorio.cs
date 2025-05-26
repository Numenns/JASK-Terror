using System.Collections;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instancia;

    public ArrayList notasGuardadas = new ArrayList();
    private int cuenta;


    public int Cuenta { get => cuenta; set => cuenta = value; }

    private int motores = 0;

    public int Motores { get => motores; set => motores = value; }


    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarNota(string texto)
    {
        notasGuardadas.Add(texto);
        Debug.Log("Nota añadida al inventario: " + texto);
    }
}

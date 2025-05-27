using System;
using System.Collections;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instancia;

    public ArrayList notasGuardadas = new ArrayList();
    private int cuenta;
    private Boolean iniciar = false;
    private Boolean perdiste = false;
    private Boolean parar = false;
    private Boolean ganaste = false;

    public int Cuenta { get => cuenta; set => cuenta = value; }
    public Boolean Iniciar { get => iniciar; set => iniciar = value; }
    public Boolean Perdiste { get => perdiste; set => perdiste = value; }
    public Boolean Parar{ get => parar; set => parar = value; }
    public Boolean Ganaste { get => ganaste; set => ganaste = value; }

    private int motores = 0;
    public int Motores { get => motores; set => motores = value; }


    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
        }
    }

    public void AgregarNota(string texto)
    {
        notasGuardadas.Add(texto);
        Debug.Log("Nota añadida al inventario: " + texto);
    }
}
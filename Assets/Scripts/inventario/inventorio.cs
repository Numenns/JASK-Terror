using System.Collections;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instancia;

    public ArrayList notasGuardadas = new ArrayList();

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

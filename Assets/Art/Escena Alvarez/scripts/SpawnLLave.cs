using UnityEngine;
using System.Collections.Generic;

public class SpawnLLave : MonoBehaviour
{
    public List<GameObject> lugaresInteractuables;
    public GameObject llave;

    public GameObject cajaCorrecta;

    private void Start()
    {
        if (lugaresInteractuables.Count > 0)
        {
            int indice = Random.Range(0, lugaresInteractuables.Count);
            cajaCorrecta = lugaresInteractuables[indice];
            Debug.Log("Caja correcta asignada: " + cajaCorrecta.name);
        }

        if (llave != null)
            llave.SetActive(false);
    }

    public void UsarLugar(GameObject caja)
    {
        Debug.Log("Caja usada: " + caja.name);
        Debug.Log("Caja correcta: " + cajaCorrecta.name);

        // Comparar por nombre en lugar de referencia exacta
        if (caja.name == cajaCorrecta.name && llave != null)
        {
            llave.SetActive(true);
            Debug.Log("caja correcta");
        }
        else
        {
            Debug.Log("No es la caja correcta");
        }
    }
}

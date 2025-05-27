using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla un efecto de titileo (encendido y apagado rápido) de una luz utilizando una corrutina.
/// El componente Light debe estar adjunto al mismo GameObject.
/// </summary>
public class luz : MonoBehaviour
{
    /// <summary>
    /// Controla si la luz está actualmente titilando. Evita múltiples corrutinas simultáneas.
    /// </summary>
    public bool titila = false;

    /// <summary>
    /// Tiempo aleatorio entre encendido y apagado, se recalcula en cada ciclo.
    /// </summary>
    public float timeDelay;

    /// <summary>
    /// Llama al efecto de titileo una vez por frame si no se está ejecutando ya.
    /// </summary>
    void Update()
    {
        if (titila == false)
        {
            StartCoroutine(LuzQueTitila());
        }
    }

    /// <summary>
    /// Corrutina que apaga y enciende la luz con un retardo aleatorio para simular titileo.
    /// </summary>
    /// <returns>IEnumerator necesario para corrutina.</returns>
    IEnumerator LuzQueTitila()
    {
        titila = true;

        this.gameObject.GetComponent<Light>().enabled = false;

        
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);

       
        this.gameObject.GetComponent<Light>().enabled = true;

       
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);

       
        titila = false;
    }
}
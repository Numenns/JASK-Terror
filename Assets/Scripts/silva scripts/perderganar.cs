using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class perderganar : MonoBehaviour
{
    public Light luz;
    public GameObject muñeco1;
    public GameObject muñeco2;
    public GameObject jumpscare;
    public AudioSource jumpscareS;
    public Boolean x=true;
    public GameObject jugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Perder();
    }

    public void Perder()
    {
        if (Inventario.Instancia.Perdiste && x)
        {
            Debug.Log("instancia funcional");
            StartCoroutine(AnimacionP());
            x = false;
        }else if(Inventario.Instancia.Ganaste && x)
        {
            StartCoroutine(AnimacionG());
            x = false;
        }
    }
    IEnumerator AnimacionP()
    {
        yield return new WaitForSeconds(1f);
        luz.intensity = 0;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 4000;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 0;
        }
        yield return new WaitForSeconds(1f);
        luz.intensity = 4000;
        
        muñeco1.active = false;
        muñeco2.active = false;
        float numero = UnityEngine.Random.Range(4, 6);
        yield return new WaitForSeconds(numero);
        jugador.GetComponent<Movement>().enabled = false;
        jugador.GetComponentInChildren<CinemachineCamera>().transform.rotation = Quaternion.Euler( 0, 90, 0);
        jumpscareS.Play();
        jumpscare.active = true;
        yield return new WaitForSeconds(2f);
        Inventario.Instancia.Perdiste = false;
        Inventario.Instancia.Ganaste = false;
        Inventario.Instancia.Iniciar = false;
        SceneManager.LoadScene("escenaSilva");

        StopAllCoroutines();
        
        
    }
    IEnumerator AnimacionG()
    {
        yield return new WaitForSeconds(1f);
        luz.intensity = 0;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 4000;
            yield return new WaitForSeconds(0.2f);
            luz.intensity = 0;
        }
        yield return new WaitForSeconds(1f);
        luz.intensity = 4000;

        muñeco1.active = false;
        muñeco2.active = false;
        Debug.Log("ganaste");
        StopAllCoroutines();


    }
}

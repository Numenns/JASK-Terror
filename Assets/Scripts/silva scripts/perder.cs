using System;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class perder : MonoBehaviour
{
    public Light luz;
    public GameObject muñeco1;
    public GameObject muñeco2;
    public Boolean x=true;

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
        if (GameManager.Instance.Perdiste && x)
        {
            StartCoroutine(AnimacionP());
            x = false;
        }else if(GameManager.Instance.Ganaste && x)
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

        StopAllCoroutines();


    }
}

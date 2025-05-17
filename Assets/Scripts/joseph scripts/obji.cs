using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    private bool yaActivado = false;

 
    public GameObject objetoAActivar;

    public void ActivarObjeto()
    {
        if (!yaActivado)
        {
            yaActivado = true;

    
            gameInstance.Instance.SumValues(1);

           
            gameObject.tag = "Untagged";

        
            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }
        }
    }
}
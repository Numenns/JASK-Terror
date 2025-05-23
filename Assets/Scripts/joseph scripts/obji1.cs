using UnityEngine;

public class ObjetoInteractivol : MonoBehaviour
{
    private bool yaActivado = false;

    public GameObject objetoAActivar;

    public void ActivarObjeto()
    {
        if (!yaActivado)
        {
            yaActivado = true;

            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }

            // Buscar el script lightControl en la escena y activar la linterna
            lightControl lc = FindObjectOfType<lightControl>();
            if (lc != null)
            {
                lc.linterapick = true;
            }

            Destroy(gameObject);
        }
    }
}
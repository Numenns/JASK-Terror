using UnityEngine;

public class ObjetoInteractivol : MonoBehaviour
{
    private bool yaActivado = false;

    public GameObject objetoAActivar;
    public AudioClip sonidoAlRecoger; // Asignar desde el Inspector

    public void ActivarObjeto()
    {
        if (!yaActivado)
        {
            yaActivado = true;

            if (objetoAActivar != null)
            {
                objetoAActivar.SetActive(true);
            }

            
            lightControl lc = FindObjectOfType<lightControl>();
            if (lc != null)
            {
                lc.linterapick = true;
            }

  
            if (sonidoAlRecoger != null)
            {
                AudioSource.PlayClipAtPoint(sonidoAlRecoger, transform.position);
            }

            Destroy(gameObject);
        }
    }
}

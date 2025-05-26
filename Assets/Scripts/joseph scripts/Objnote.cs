using UnityEngine;

public class ObjNote : MonoBehaviour
{
    [Header("Mensaje mostrado al mirar el objeto")]
    public GameObject mensajeUI;

    [Header("Texto que se guarda al recoger")]
    [TextArea]
    public string textoNota;

    [Header("Sonido al recoger la nota")]
    public AudioClip sonidoRecoger;

    private bool recogido = false;
    private AudioSource audioSource;

    private void Awake()
    {
        // Intenta obtener un AudioSource del mismo objeto o lo añade si no existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public bool EstaDisponible()
    {
        return !recogido && gameObject.activeInHierarchy;
    }

    public void MostrarMensaje()
    {
        if (EstaDisponible() && mensajeUI != null)
        {
            mensajeUI.SetActive(true);
        }
    }

    public void OcultarMensaje()
    {
        if (mensajeUI != null)
        {
            mensajeUI.SetActive(false);
        }
    }

    public void ActivarObjeto()
    {
        if (EstaDisponible())
        {
            recogido = true;

            // Reproducir sonido si hay uno asignado
            if (sonidoRecoger != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoRecoger);
            }

            // Mostrar en consola el texto que se va a añadir
            Debug.Log("Texto a añadir al inventario: " + textoNota);

            // Agregar texto al inventario y mostrar confirmación en consola
            if (Inventario.Instancia != null)
            {
                Inventario.Instancia.AgregarNota(textoNota);
                Debug.Log("Se agregó al inventario: " + textoNota);
            }

            OcultarMensaje();

            // Opcional: retrasar la desactivación para que se escuche el sonido
            StartCoroutine(DesactivarTrasSonido());
        }
    }

    private System.Collections.IEnumerator DesactivarTrasSonido()
    {
        if (sonidoRecoger != null)
        {
            yield return new WaitForSeconds(sonidoRecoger.length);
        }
        gameObject.SetActive(false);
    }
}

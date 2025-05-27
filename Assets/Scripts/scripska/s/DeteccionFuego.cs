using UnityEngine;
using System.Collections;

public class DetectorFuego : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;

    private Coroutine parpadeoCoroutine;
    private bool estaParpadeando = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!estaParpadeando)
            {
                parpadeoCoroutine = StartCoroutine(ParpadeoCanvas());
                estaParpadeando = true;
            }

            RayRecolectables recolector = FindFirstObjectByType<RayRecolectables>();
            if (recolector != null)
            {
                recolector.ActivarGameOver();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (estaParpadeando)
            {
                StopCoroutine(parpadeoCoroutine);
                estaParpadeando = false;

                // Restaurar canvas a invisible
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }

            RayRecolectables recolector = FindFirstObjectByType<RayRecolectables>();
            if (recolector != null)
            {
                recolector.CancelarGameOver();
            }
        }
    }

    private IEnumerator ParpadeoCanvas()
    {
        while (true)
        {
            // Fade in
            float t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
                yield return null;
            }

            // Fade out
            t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
                yield return null;
            }
        }
    }
}

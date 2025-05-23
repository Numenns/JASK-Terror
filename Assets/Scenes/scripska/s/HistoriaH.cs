using UnityEngine;

public class DestruccionConAnimacion : MonoBehaviour
{
    public float duracion = 0.5f;

    public void EjecutarAnimacion()
    {
        StartCoroutine(AnimarYDestruir());
    }

    System.Collections.IEnumerator AnimarYDestruir()
    {
        Vector3 escalaInicial = transform.localScale;
        Vector3 escalaFinal = Vector3.zero;

        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, tiempo / duracion);
            yield return null;
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class lucesIntermitentes : MonoBehaviour
{
    public float velocidadParpadeo;

    private Light luz;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        luz = GetComponent<Light>();
        StartCoroutine(Parpadeo());
        velocidadParpadeo = Random.Range(0.1f, 1f);
    }

    IEnumerator Parpadeo()
    {
        while (true)
        {
            luz.enabled = !luz.enabled;
            yield return new WaitForSeconds(velocidadParpadeo);
        }
    }
}

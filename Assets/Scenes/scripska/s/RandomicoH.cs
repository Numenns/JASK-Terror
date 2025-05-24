using UnityEngine;

public class RandomicoH : MonoBehaviour
{
    public GameObject HojasB1;
    public GameObject HojasB2;
    public GameObject HojasB3;

    private int resultado;

    void Start()
    {
        resultado = Random.Range(1, 4); // De 1 a 3 inclusive

        if (resultado == 1)
        {
            HojasB1.SetActive(true);
        }
        else if (resultado == 2)
        {
            HojasB2.SetActive(true);
        }
        else if (resultado == 3)
        {
            HojasB3.SetActive(true);
        }
    }
}
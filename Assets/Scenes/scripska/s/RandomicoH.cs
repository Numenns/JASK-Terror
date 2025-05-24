using UnityEngine;

public class RandomicoH : MonoBehaviour
{
    public GameObject prefabHistoriaClinica;
    public int cantidad = 5;
    public Vector3 areaMin = new Vector3(-10, 0, -10);
    public Vector3 areaMax = new Vector3(10, 0, 10);


    void Start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 posicionAleatoria = new Vector3(
                Random.Range(areaMin.x, areaMax.x),
                Random.Range(areaMin.y, areaMax.y),
                Random.Range(areaMin.z, areaMax.z)
            );

            GameObject historia = Instantiate(prefabHistoriaClinica, posicionAleatoria, Quaternion.identity);
            historia.tag = "HistoriaClinica";
            historia.layer = LayerMask.NameToLayer("HistoriaClin");
        }
    }
}

  


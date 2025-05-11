using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class contar_c : MonoBehaviour
{
    public GameObject herramienta;
    public Transform posicion1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("zona"))
        {
            GameManager.Instance.SumValues(true, true);
            Debug.Log(GameManager.Instance.ScoreC.ToString());
            Destroy(gameObject);
            Instantiate(herramienta, posicion1.position, gameObject.transform.rotation);

        }
    }
}

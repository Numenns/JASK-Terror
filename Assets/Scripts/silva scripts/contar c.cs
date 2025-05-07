using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class contar_c : MonoBehaviour
{ 
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
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.SumValues(false, false);
    }
}

using System.Collections;
using UnityEngine;

public class fijarjugador : MonoBehaviour
{
    public GameObject muñeco;
    public AudioSource audio1;
    public AudioSource audio2;
    public Canvas tiempo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            audio1.Play();

            tiempo.gameObject.SetActive(true);
            Vector3 x = new Vector3(-1.828f, 2f, 0.335f);
            GameManager.Instance.Iniciar = true;
            other.gameObject.transform.position = x;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Movement>().speed = 0;
        }
    }

}

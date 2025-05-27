using System.Collections;
using UnityEngine;

public class fijarjugador : MonoBehaviour
{
    public GameObject muñeco;
    public AudioSource musica;
    public AudioSource respiracion;
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
            musica.Play();
            respiracion.Play();

            tiempo.gameObject.SetActive(true);
            Vector3 x = new Vector3(-1.828f, 2f, 0.335f);
            Inventario.Instancia.Iniciar = true;
            other.gameObject.transform.position = x;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Movement>().speed = 0;
        }
    }

}

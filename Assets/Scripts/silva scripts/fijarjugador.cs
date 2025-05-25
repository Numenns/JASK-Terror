using UnityEngine;

public class fijarjugador : MonoBehaviour
{
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
        Vector3 x = new Vector3(-1.828f, 2f, 0.335f);
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = x;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Movement>().speed = 0;
        }
    }
}

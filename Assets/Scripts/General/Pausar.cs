using Unity.VisualScripting;
using UnityEngine;

public class Pausar : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelAudio;
    private bool pausado = false;
    private KeyCode teclaPausa = KeyCode.Escape;
    public GameObject Movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teclaPausa))
        {
            Pausa();
        }
    }

    public void Pausa()

    {

        if (pausado)
        {
            Time.timeScale = 1;
            panelPausa.SetActive(false);
            panelAudio.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Movement.GetComponent<Movement>().enabled = true;
            pausado = false;
        }
        else
        {
            Time.timeScale = 0;
            panelPausa.SetActive(true);
            panelAudio.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.GetComponent<Movement>().enabled = false;
            pausado = true;
        }

    }
}



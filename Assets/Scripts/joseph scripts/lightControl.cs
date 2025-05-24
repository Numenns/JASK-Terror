using UnityEngine;

public class lightControl : MonoBehaviour
{
    public GameObject LL;
    public GameObject LP;

    public bool linterapick = true;

    private int estado = 0;

    void Update()
    {
        if (!linterapick) return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            estado++;

            if (estado > 2)
                estado = 0;

            switch (estado)
            {
                case 0:
                    LL.SetActive(false);
                    LP.SetActive(false);
                    break;
                case 1:
                    LL.SetActive(true);
                    LP.SetActive(false);
                    break;
                case 2:
                    LL.SetActive(false);
                    LP.SetActive(true);
                    break;
            }
        }
    }
}
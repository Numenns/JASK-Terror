using UnityEngine;
using System;

public class spawn : MonoBehaviour
{
    private int X;
    public Transform P;
    public GameObject ObjC;
    public GameObject ObjE;
    public GameObject ObjCA;
    void Start()
    {
        InvokeRepeating("generar", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void generar()
    {
        X = UnityEngine.Random.Range(1, 4);
        switch (X)
        {
            case 1:
                Instantiate(ObjC, P.position, P.rotation);
                break;
            case 2:
                Instantiate(ObjE, P.position, P.rotation);
                break;
            case 3:
                Instantiate(ObjCA, P.position, P.rotation);
                break;
        }
    }
}

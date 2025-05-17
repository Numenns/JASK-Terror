using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool obj1 = false;
    private bool obj2 = false;
    private bool obj3 = false;
    private bool obj4 = false;
    private bool obj5 = false;
    private int velocidad;

    public bool Obj1 { get => obj1; set => obj1 = value; }
    public bool Obj2 { get => obj2; set => obj2 = value; }
    public bool Obj3 { get => obj3; set => obj3 = value; }
    public bool Obj4 { get => obj4; set => obj4 = value; }
    public bool Obj5 { get => obj5; set => obj5 = value; }
    public bool Velocidad { get => obj5; set => obj5 = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void aumentar_estres()
    {

    }
}
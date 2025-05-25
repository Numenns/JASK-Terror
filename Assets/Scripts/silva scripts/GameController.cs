using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int cuenta;
    private int velocidad;

    public int Cuenta { get => cuenta; set => cuenta = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           
        }
    }
    private void aumentar_estres()
    {

    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int cuenta;
    private Boolean iniciar = false;
    private Boolean perdiste = false;

    public int Cuenta { get => cuenta; set => cuenta = value; }
    public Boolean Iniciar { get => iniciar; set => iniciar = value; }
    public Boolean Perdiste { get => perdiste; set => perdiste = value; }

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
    private void Update()
    {
        if (perdiste)
        {
            Debug.Log("perdiste");
        }
    }
}
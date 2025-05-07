using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    private bool F1 = false;
    private int score_c = 0;
    private int score_ca = 0;

    public bool f1 { get => F1; set => F1 = value; }
    public int ScoreC { get => score_c; set => score_c = value; }
    public int ScoreCA { get => score_ca; set => score_ca = value; }

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
    public void SumValues(bool count, Boolean x)
    {
        if (x == true)
        {
            F1 = count;
        }
        else
        {
            F1 = count;
        }
       
    }
    public void SumValues_c(int count, Boolean x)
    {
        if (x == true)
        {
            score_c += count;
        }
        else
        {
            score_c -= count;
        }
        

    }
    public void SumValues_ca(int count, Boolean x)
    {
        if (x == true)
        {
            score_ca += count;
        }
        else
        {
            score_ca -= count;
        }
        

    }

}

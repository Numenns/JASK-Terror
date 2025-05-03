using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    private int score = 0;
    private int score_c = 0;
    private int score_ca = 0;

    public int Score { get => score; set => score = value; }
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
    public void SumValues(int count, Boolean x)
    {
        if (x == true)
        {
            score += count;
        }
        else
        {
            score -= count;
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

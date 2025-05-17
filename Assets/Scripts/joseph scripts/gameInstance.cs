using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class gameInstance : MonoBehaviour
{
    public static gameInstance Instance;

    private int motores = 0;

    public int Motores { get => motores; set => motores = value; }

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SumValues(int count)
    {
        motores += count;
    }
}
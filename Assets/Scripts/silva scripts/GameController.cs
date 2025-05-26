using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int cuenta;
    private Boolean iniciar = false;
    private Boolean perdiste = false;
    private Boolean parar = false;
    private Boolean ganaste = false;

    public int Cuenta { get => cuenta; set => cuenta = value; }
    public Boolean Iniciar { get => iniciar; set => iniciar = value; }
    public Boolean Perdiste { get => perdiste; set => perdiste = value; }
    public Boolean Parar { get => parar; set => parar = value; }
    public Boolean Ganaste { get => ganaste; set => ganaste = value; }

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
            //Debug.Log("perdiste");
        }
    }
    public void GuardarDatos()
    {
        GameManagerData data = new GameManagerData
        {
            cuenta = this.Cuenta,
            iniciar = this.Iniciar,
            perdiste = this.Perdiste,
            parar = this.Parar,
            ganaste = this.Ganaste
        };

        string json = JsonUtility.ToJson(data, true);
        string path = Application.persistentDataPath + "/gamemanager.json";
        File.WriteAllText(path, json);

        Debug.Log($"Datos guardados en: {path}");
    }
    public void CargarDatos()
    {
        string path = Application.persistentDataPath + "/gamemanager.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameManagerData data = JsonUtility.FromJson<GameManagerData>(json);

            this.Cuenta = data.cuenta;
            this.Iniciar = data.iniciar;
            this.Perdiste = data.perdiste;
            this.Parar = data.parar;
            this.Ganaste = data.ganaste;

            Debug.Log("Datos cargados correctamente");
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo JSON");
        }
    }
    [System.Serializable]
    public class GameManagerData
    {
        public int cuenta;
        public bool iniciar;
        public bool perdiste;
        public bool parar;
        public bool ganaste;
    }

}
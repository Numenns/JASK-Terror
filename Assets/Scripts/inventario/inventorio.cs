using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instancia;

    public ArrayList notasGuardadas = new ArrayList();
    private int cuenta;
    private Boolean iniciar = false;
    private Boolean perdiste = false;
    private Boolean parar = false;
    private Boolean ganaste = false;


    public ArrayList Notasguardada { get => notasGuardadas; set => notasGuardadas = value; }
    public int Cuenta { get => cuenta; set => cuenta = value; }
    public Boolean Iniciar { get => iniciar; set => iniciar = value; }
    public Boolean Perdiste { get => perdiste; set => perdiste = value; }
    public Boolean Parar{ get => parar; set => parar = value; }
    public Boolean Ganaste { get => ganaste; set => ganaste = value; }

    private int motores = 0;
    private string temp;
    private float tiempoActual = 0;
    private string nombre;
    private int notas;
    

    public float TiempoActual { get => tiempoActual; set => tiempoActual = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    
    public String Temp { get => temp; set => temp = value; }
    public int Notas { get => notasGuardadas.Count; set => notas = value; }
    public int Motores { get => motores; set => motores = value; }

    [System.Serializable]
    public class GameManagerData
    {
        public String temp;
        public String nombre;
        public int Notas;
    }
    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarNota(string texto)
    {
        notasGuardadas.Add(texto);
        Debug.Log("Nota añadida al inventario: " + texto);
    }
    private void Update()
    {
                tiempoActual += Time.deltaTime;
                int minutos = Mathf.FloorToInt(tiempoActual / 60);
                int segundos = Mathf.FloorToInt(tiempoActual % 60);
                temp= minutos + ":" + segundos;
    }
    public void GuardarDatos()
    {
        GameManagerData data = new GameManagerData
        {
            temp = this.temp,
            nombre = this.nombre,
            Notas = this.Notas
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

            this.temp = data.temp;
            this.nombre = data.nombre;
            this.Notas = data.Notas;

            Debug.Log("Datos cargados correctamente");
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo JSON");
        }
    }

}
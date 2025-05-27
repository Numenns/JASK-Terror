using System;
using System.Collections;
using System.Collections.Generic;
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
    public List<GameManagerData> datosCargados = new List<GameManagerData>();

    public float TiempoActual { get => tiempoActual; set => tiempoActual = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public String Temp { get => temp; set => temp = value; }
    public int Notas { get => notasGuardadas.Count; set => notas = value; }
    public int Motores { get => motores; set => motores = value; }
    public List<GameManagerData> DatosCargados { get => datosCargados; set => datosCargados = value; }

    [System.Serializable]
    public class GameManagerData
    {
        public String temp;
        public String nombre;
        public int Notas;
    }
    [System.Serializable]
    public class ListaDeDatos
    {
        public List<GameManagerData> lista = new List<GameManagerData>();
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
        // Creamos un nuevo objeto con los datos actuales
        GameManagerData data = new GameManagerData
        {
            temp = this.temp,
            nombre = this.nombre,
            Notas = this.Notas
        };

        datosCargados.Add(data); // Añadimos a la lista

        // Empaquetamos la lista para serializarla
        ListaDeDatos listaParaGuardar = new ListaDeDatos();
        listaParaGuardar.lista = datosCargados;

        string json = JsonUtility.ToJson(listaParaGuardar, true);
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
            ListaDeDatos listaCargada = JsonUtility.FromJson<ListaDeDatos>(json);

            datosCargados = listaCargada.lista;

            // Si quieres, también actualizas los datos actuales con el último de la lista:
            if (datosCargados.Count > 0)
            {
                GameManagerData ultimo = datosCargados[datosCargados.Count - 1];
                this.temp = ultimo.temp;
                this.nombre = ultimo.nombre;
                this.Notas = ultimo.Notas;
            }

            Debug.Log("Datos cargados correctamente");
        }
        else
        {
            Debug.LogWarning("No se encontró el archivo JSON");
        }
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Gestiona el inventario del juego, incluyendo notas, estados del juego, temporizador y guardado/carga de datos en formato JSON.
/// Implementa el patrón Singleton para asegurar una única instancia persistente en el juego.
/// </summary>
public class Inventario : MonoBehaviour
{
    /// <summary>
    /// Instancia única del inventario, siguiendo el patrón Singleton.
    /// </summary>
    public static Inventario Instancia;

    /// <summary>
    /// Lista de notas almacenadas en el inventario.
    /// </summary>
    public ArrayList notasGuardadas = new ArrayList();

    /// <summary>
    /// Contador general utilizado en el juego.
    /// </summary>
    private int cuenta;

    /// <summary>
    /// Indica si el juego ha iniciado.
    /// </summary>
    private Boolean iniciar = false;

    /// <summary>
    /// Indica si el jugador ha perdido.
    /// </summary>
    private Boolean perdiste = false;

    /// <summary>
    /// Indica si el juego debe detenerse.
    /// </summary>
    private Boolean parar = false;

    /// <summary>
    /// Indica si el jugador ha ganado.
    /// </summary>
    private Boolean ganaste = false;

    /// <summary>
    /// Obtiene o establece la lista de notas guardadas.
    /// </summary>
    public ArrayList Notasguardada { get => notasGuardadas; set => notasGuardadas = value; }

    /// <summary>
    /// Obtiene o establece el contador general del juego.
    /// </summary>
    public int Cuenta { get => cuenta; set => cuenta = value; }

    /// <summary>
    /// Obtiene o establece si el juego ha iniciado.
    /// </summary>
    public Boolean Iniciar { get => iniciar; set => iniciar = value; }

    /// <summary>
    /// Obtiene o establece si el jugador ha perdido.
    /// </summary>
    public Boolean Perdiste { get => perdiste; set => perdiste = value; }

    /// <summary>
    /// Obtiene o establece si el juego debe detenerse.
    /// </summary>
    public Boolean Parar { get => parar; set => parar = value; }

    /// <summary>
    /// Obtiene o establece si el jugador ha ganado.
    /// </summary>
    public Boolean Ganaste { get => ganaste; set => ganaste = value; }

    /// <summary>
    /// Contador de motores en el inventario.
    /// </summary>
    private int motores = 0;

    /// <summary>
    /// Cadena que almacena el tiempo formateado (minutos:segundos).
    /// </summary>
    private string temp;

    /// <summary>
    /// Tiempo acumulado en segundos desde el inicio del juego.
    /// </summary>
    private float tiempoActual = 0;

    /// <summary>
    /// Nombre del jugador o del contexto del juego.
    /// </summary>
    private string nombre;

    /// <summary>
    /// Número de notas almacenadas (basado en el conteo de notasGuardadas).
    /// </summary>
    private int notas;

    /// <summary>
    /// Lista de datos del juego cargados desde un archivo JSON.
    /// </summary>
    public List<GameManagerData> datosCargados = new List<GameManagerData>();

    /// <summary>
    /// Obtiene o establece el tiempo acumulado del juego en segundos.
    /// </summary>
    public float TiempoActual { get => tiempoActual; set => tiempoActual = value; }

    /// <summary>
    /// Obtiene o establece el nombre del jugador o contexto.
    /// </summary>
    public string Nombre { get => nombre; set => nombre = value; }

    /// <summary>
    /// Obtiene o establece la cadena de tiempo formateada (minutos:segundos).
    /// </summary>
    public String Temp { get => temp; set => temp = value; }

    /// <summary>
    /// Obtiene o establece el número de notas en el inventario.
    /// </summary>
    public int Notas { get => notasGuardadas.Count; set => notas = value; }

    /// <summary>
    /// Obtiene o establece el número de motores en el inventario.
    /// </summary>
    public int Motores { get => motores; set => motores = value; }

    /// <summary>
    /// Obtiene o establece la lista de datos cargados desde el archivo JSON.
    /// </summary>
    public List<GameManagerData> DatosCargados { get => datosCargados; set => datosCargados = value; }

    /// <summary>
    /// Clase que representa los datos del juego para guardar/cargar en formato JSON.
    /// </summary>
    [System.Serializable]
    public class GameManagerData
    {
        /// <summary>
        /// Cadena que almacena el tiempo formateado (minutos:segundos).
        /// </summary>
        public String temp;

        /// <summary>
        /// Nombre del jugador o contexto del juego.
        /// </summary>
        public String nombre;

        /// <summary>
        /// Número de notas guardadas.
        /// </summary>
        public int Notas;
    }

    /// <summary>
    /// Clase contenedora para serializar una lista de datos del juego en formato JSON.
    /// </summary>
    [System.Serializable]
    public class ListaDeDatos
    {
        /// <summary>
        /// Lista de datos del juego para serialización.
        /// </summary>
        public List<GameManagerData> lista = new List<GameManagerData>();
    }

    /// <summary>
    /// Configura la instancia Singleton del inventario, asegurando que persista entre escenas.
    /// Destruye instancias duplicadas si existen.
    /// </summary>
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

    /// <summary>
    /// Añade una nota al inventario y registra la acción en la consola de depuración.
    /// </summary>
    /// <param name="texto">El texto de la nota a añadir.</param>
    public void AgregarNota(string texto)
    {
        notasGuardadas.Add(texto);
        Debug.Log("Nota añadida al inventario: " + texto);
    }

    /// <summary>
    /// Actualiza el temporizador del juego, calculando el tiempo acumulado y formateándolo como minutos:segundos.
    /// </summary>
    private void Update()
    {
        tiempoActual += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempoActual / 60);
        int segundos = Mathf.FloorToInt(tiempoActual % 60);
        temp = minutos + ":" + segundos;
    }

    /// <summary>
    /// Guarda los datos actuales del juego (tiempo, nombre y número de notas) en un archivo JSON.
    /// </summary>
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

    /// <summary>
    /// Carga los datos del juego desde un archivo JSON y actualiza las propiedades correspondientes.
    /// </summary>
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
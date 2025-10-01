using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEmotivamente : MonoBehaviour
{
   //Este script será un singleton que llevará todos los datos al final

    public static DatosEmotivamente Instance { get; private set; }

    //Datos iniciales
    public string Name;
    public string edad;
    public string residencia;

    //Nivel 1
    //Actividad 1
    public int puntuacionPosN1_A1;
    public int puntuacionNegN1_A1;

    //Actividad 2
    public int puntuacionPosN1_A2;
    public int puntuacionNegN1_A2;

    //Actividad 3
    public int puntuacionPosN1_A3;
    public int puntuacionNegN1_A3;

    //Actividad 4
    public int puntuacionN1_A4_1;
    public float tiempoN1_A4_1;
    public int puntuacionN1_A4_2;
    public float tiempoN1_A4_2;

    //Actividad 5
    public int puntuacionN1_A5;
    public float tiempoN1_A5;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

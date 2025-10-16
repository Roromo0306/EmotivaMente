using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronómetroN1_A4 : MonoBehaviour
{
    //Booleano para saber si está activo
    public bool iniciado = false;

    //Tiempo acumulado
    public float tiempo = 0f;

    //Funcion para empezar el cronometro
    public void EmpezarCrono()
    {
        tiempo = 0f;
        iniciado = true;
    }

    //Funcion para parar el cronometro
    public void PararCrono()
    {
        iniciado = false;
    }

    private void Update()
    {
        if (iniciado)
        {
            tiempo += Time.deltaTime;
        }
    }

    public int Tiempo => (int)tiempo; //convierte el float en int
}

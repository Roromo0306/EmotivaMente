using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronómetroN1_A4 : MonoBehaviour
{
    //Desde estos objetos iniciaremos y pararemos el cronometro
    public GameObject cesta_actividad;
    public Canvas canvasInicio;

    //Booleano para saber si está activo
    public bool iniciado = false;

    //Tiempo acumulado
    public float tiempo = 0f;

    //Funcion para empezar el cronometro
    public void EmpezarCrono()
    {
        iniciado = true;
    }

    //Funcion para parar el cronometro
    public void PararCrono()
    {
        iniciado = false;
        CalcularTiempo();
    }

    private void Update()
    {
        if (iniciado)
        {
            tiempo += Time.deltaTime;
        }
    }

    private void CalcularTiempo()
    {

    }
}

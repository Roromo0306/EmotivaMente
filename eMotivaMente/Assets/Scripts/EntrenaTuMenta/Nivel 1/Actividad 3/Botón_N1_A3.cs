using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botón_N1_A3 : MonoBehaviour
{
    public AudioSource tren, coche;
    public int contador = 4, opcion, aciertos = 0, fallos = 0, BCT = 0;
    public Button Coche, Tren, start;
    public bool empezar = false;
    void Start()
    {
        Coche.onClick.AddListener(botonC);
        Tren.onClick.AddListener(botonT);
        start.onClick.AddListener(funcion);
    }


    public void botonC()
    {
        BCT = 1; //El botón del coche va a dar 1

        if (opcion == BCT)
        {
            aciertos++;
            empezar = false;
        }
        else
        {
            fallos++;
            empezar = false;
        }

    }

    public void botonT()
    {
        BCT = 2; //El botón del tren va a dar 2

        if (opcion == BCT)
        {
            aciertos++;
            empezar = false;
        }
        else
        {
            fallos++;
            empezar = false;
        }

    }
    public void funcion()
    {
        empezar = true;

        BCT = 0;
        opcion = Random.Range(1, 3);

        if(opcion == 1)
        {
            tren.Play();
        }

        if(opcion == 2)
        {
            coche.Play();
        }
    }

    
    void Update()
    {
        if (empezar)
        {
            start.gameObject.SetActive(false);
        }

        if(!empezar)
        {
            start.gameObject.SetActive(true);
        }
    }
}

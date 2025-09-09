using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Botón_N1_A3 : MonoBehaviour
{
    public AudioSource tren, coche;
    public int opcion, aciertos = 0, fallos = 0, BCT = 0, contadorEjemplo = 0, contadorActividad = 0;
    public Button Coche, Tren, start;
    public bool empezar = false;
    public Canvas canvas, canvasfinal;

    public TextMeshProUGUI texto2, texto1, texto3;
    void Start()
    {
        Coche.onClick.AddListener(botonC);
        Tren.onClick.AddListener(botonT);
        start.onClick.AddListener(funcion);

        texto1.gameObject.SetActive(false);
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);
        canvasfinal.enabled = false;


        //Reinicio contadores
        contadorActividad = 0;
        aciertos = fallos = 0;
    }


    public void botonC()
    {
        Canvas_N1_A3 c = canvas.GetComponent<Canvas_N1_A3>();
        BCT = 1; //El botón del coche va a dar 1

        //Esto detecta si estamos en un ejemplo o en un actividad y sube el contador
        if (c.modo == 1)
        {
            contadorEjemplo++;
        }

        if (c.modo == 2)
        {
            contadorActividad++;
        }

        //Esto detecta si se ha acertado o no
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
        Canvas_N1_A3 c = canvas.GetComponent<Canvas_N1_A3>();

        BCT = 2; //El botón del tren va a dar 2

        //Esto detecta si estamos en un ejemplo o en un actividad y sube el contador
        if (c.modo == 1)
        {
            contadorEjemplo++;
        }

        if (c.modo == 2)
        {
            contadorActividad++;
        }

        //Esto detecta si se ha acertado o no
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
        Canvas_N1_A3 c = canvas.GetComponent<Canvas_N1_A3>();
        CanvasFinal_N1_A3 cf = canvasfinal.GetComponent<CanvasFinal_N1_A3>();

        texto3.text = "Lo has hecho bien, has tenido " + aciertos + " puntos y " + fallos + " fallos. Puedes volver a intentarlo para mejorar o puedes volver al menú para continuar con la siguiente actividad";

        if (empezar)
        {
            start.gameObject.SetActive(false);
        }

        if(!empezar)
        {
            start.gameObject.SetActive(true);
        }

        if (c.modo == 1 && contadorEjemplo == 3)
        {
            Time.timeScale = 0;
            canvas.enabled = true;

            //Reinicio contadores
            contadorEjemplo = 0;
            aciertos = fallos = 0;

        }

        if (c.modo == 2 && contadorActividad == 7)
        {
            Time.timeScale = 0;

            if(fallos == 3)
            {
                canvasfinal.enabled = true;
                texto2.gameObject.SetActive(true);
                cf.Menu.gameObject.SetActive(false);
            }
            else
            {
                if(fallos <3 && aciertos > 0)
                {
                    canvasfinal.enabled = true;
                    texto3.gameObject.SetActive(true);

                    Menu_Nivel1_Entrena.n3 = true;
                    cf.Menu.gameObject.SetActive(true);
                }
                else
                {
                    if(aciertos >0 && fallos == 0)
                    {
                        canvasfinal.enabled= true;
                        texto1.gameObject.SetActive(true);

                        Menu_Nivel1_Entrena.n3 = true;
                        cf.Menu.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector_Colision_N2_A3 : MonoBehaviour
{
    [Header("Manager")]
    public GameObject manager; //Referencia al manager

    [Header("Puntos")]
    public int puntosPositivos = 0; //Variable de puntos positivos
    public int puntosNegativos = 0; //Variable de puntos negativos

    [Header("Canvas Menu")]
    public Canvas canvas;


    private Image sp; //Referencia a la imagen que lleva el generador
    void Start()
    {
        sp = GetComponent<Image>(); //Adquiero el componente imagen
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Manager_N2_A3 man = manager.GetComponent<Manager_N2_A3>();
        CanvasMenu_N2_A3 can = canvas.GetComponent<CanvasMenu_N2_A3>();

        if(collision.gameObject.name == "Maleta")
        {
            if(can.modo == 2)
            {
                if(sp.sprite.name == "abrigo" || sp.sprite.name == "bota" || sp.sprite.name == "bufanda" || sp.sprite.name == "calcetines" || sp.sprite.name == "camiseta larga" || sp.sprite.name == "cazadora ejemplo còpia" || sp.sprite.name == "gorro" || sp.sprite.name == "guantes" || sp.sprite.name == "jersey" || sp.sprite.name == "manoplas" || sp.sprite.name == "pantalón" || sp.sprite.name == "sueter")
                {
                    puntosPositivos++;
                }
                else
                {
                    puntosNegativos++;
                }
            }
        }
    }
}

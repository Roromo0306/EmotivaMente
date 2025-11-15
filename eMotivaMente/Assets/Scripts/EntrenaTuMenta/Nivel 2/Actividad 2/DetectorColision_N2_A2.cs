using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectorColision_N2_A2 : MonoBehaviour
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
        Manager_N2_A2 man = manager.GetComponent<Manager_N2_A2>(); //Obtengo una referencia al manager
        CanvasMenu_N2_A2 can = canvas.GetComponent<CanvasMenu_N2_A2>(); //Obtengo una referencia al canvas

        if(collision.gameObject.name == "Cocina")
        {
            if(can.modo == 2)
            {
                if (sp.sprite.name == "cafetera" ||  sp.sprite.name == "cazuela" || sp.sprite.name == "cuchara" || sp.sprite.name == "sarten")
                {
                    puntosPositivos++;
                }
                else
                {
                    puntosNegativos++;
                }
            }
        }

        if (collision.gameObject.name == "Banno")
        {
            if (can.modo == 2)
            {
                if (sp.sprite.name == "cepillo dientes" || sp.sprite.name == "maquillaje" || sp.sprite.name == "papel higienico" || sp.sprite.name == "pasta dientes" || sp.sprite.name == "peine" || sp.sprite.name == "perfume" || sp.sprite.name == "toalla")
                {
                    puntosPositivos++;
                }
                else
                {
                    puntosNegativos++;
                }
            }
        }

        if (collision.gameObject.name == "Armario")
        {
            if (can.modo == 2)
            {
                if (sp.sprite.name == "camisa" || sp.sprite.name == "camiseta" || sp.sprite.name == "traje" || sp.sprite.name == "vestido")
                {
                    puntosPositivos++;
                }
                else
                {
                    puntosNegativos++;
                }
            }
        }

        if (collision.gameObject.name == "Bolsa")
        {
            if (can.modo == 2)
            {
                if (sp.sprite.name == "pantalon" || sp.sprite.name == "peine" || sp.sprite.name == "Donut-g 65b 8129e 2_1280_0" || sp.sprite.name == "cuchillo" || sp.sprite.name == "jabon" || sp.sprite.name == "gorra")
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

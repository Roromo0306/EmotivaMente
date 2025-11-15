using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detector_Colision_N2_A1 : MonoBehaviour
{
    [Header("Manager")]
    public GameObject manager;//Referencia al manager

    [Header("Puntos")]
    public int puntosPositivos = 0; //Variable de puntos positivos
    public int puntosNegativos = 0; //Variable de puntos negativos

    private Image sp; //Referencia a la imagen que lleva el generador
    //public bool parada = false;
    void Start()
    {
        sp = GetComponent<Image>(); //Adquiero el componente imagen
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Manager_N2_A1 m = manager.GetComponent<Manager_N2_A1>(); //Obtengo una referencia al manager

        if (collision.gameObject.name == "Cesta") //Esto es lo que sucede si colisiona con cesta
        {
            if (sp.sprite.name == "tenisBall" || sp.sprite.name == "gorra2" || sp.sprite.name == "shose" || sp.sprite.name == "baboshka" || sp.sprite.name == "dress" || sp.sprite.name == "grasHat")
            {
                //Esto es porque son los objetos del ejemplo
                //parada = true;
            }

            if (sp.sprite.name == "zapatos" || sp.sprite.name == "lazo2" || sp.sprite.name == "tShirt" || sp.sprite.name == "bantik" || sp.sprite.name == "planta")
            {
                puntosPositivos++; 
            }
            else
            {
                puntosNegativos++;
            }
        }

        if (collision.gameObject.name == "Bolsa") //Esto es lo que sucede si colisiona con bolsa
        {
            if (sp.sprite.name == "tenisBall" || sp.sprite.name == "gorra2" || sp.sprite.name == "shose" || sp.sprite.name == "baboshka" || sp.sprite.name == "dress" || sp.sprite.name == "grasHat")
            {
                //Esto es porque son los objetos del ejemplo
                //parada = true;
            }

            if (sp.sprite.name == "socks" || sp.sprite.name == "zapatillas2" || sp.sprite.name == "sportSuit" || sp.sprite.name == "tenisBall" || sp.sprite.name == "tenisStik" || sp.sprite.name == "BasketBall" || sp.sprite.name == "hat")
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

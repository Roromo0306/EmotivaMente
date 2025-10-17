using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColision : MonoBehaviour
{
    public int puntospos=0;
    public int puntosneg=0;

    private GameObject esto;
    private SpriteRenderer sp;

    public bool parada = false; //Uso este bool para parar la corrutina
    public Canvas canvaInicio;

    public GameObject manager;
    private void Start()
    {
        esto = this.gameObject;
        sp = esto.GetComponent<SpriteRenderer>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Canvas_Inicio_N1_A1 c = canvaInicio.GetComponent<Canvas_Inicio_N1_A1>();
        N1_Actividad1 n = manager.GetComponent<N1_Actividad1>();
        if(c.modo == 2)
        { 
        if (collision.gameObject.CompareTag("Maleta"))
        {
            if(sp.sprite.name == "Assets_2")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_3")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_9")
            {
                puntosneg++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_0")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "m�vil")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_4")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_5")
            {
                puntosneg++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_1")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_10")
            {
                puntosneg++;
                parada = true;
            }

            if(sp.sprite.name == "Assets_6")
            {
                puntospos++;
                parada = true;
                n.Fase = true;
            }
        }
        }
    }
}

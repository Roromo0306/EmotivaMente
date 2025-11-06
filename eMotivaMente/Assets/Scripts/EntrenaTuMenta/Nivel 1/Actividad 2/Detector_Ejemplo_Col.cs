using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Ejemplo_Col : MonoBehaviour
{
    private SpriteRenderer sp;

    public bool parada = false;

    public GameObject manager;

    public int puntosPositivos = 0;
    public int puntosNegativos = 0;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Manager_N1_A2 m = manager.GetComponent<Manager_N1_A2>();
        if(collision.gameObject.name == "Caja")
        {
           if(sp.sprite.name == "tijeras ejemplo" ||  sp.sprite.name == "pera" || sp.sprite.name =="arbol ejemplo")
           {
                parada = true;
           }

           if(sp.sprite.name == "corcho" || sp.sprite.name == "tijeras" || sp.sprite.name == "botella")
           {
                puntosPositivos++;
                Debug.Log("Caja");
            }
           else
           {
                puntosNegativos++;
           }
        }

        if(collision.gameObject.name == "Plato")
        {
            if (sp.sprite.name == "tijeras ejemplo" || sp.sprite.name == "pera" || sp.sprite.name == "arbol ejemplo")
            {
                parada = true;
            }

            if(sp.sprite.name == "queso" || sp.sprite.name == "manzana"|| sp.sprite.name == "fresa" || sp.sprite.name =="zanahoria"|| sp.sprite.name =="pan"|| sp.sprite.name =="pez"|| sp.sprite.name == "cerezas" || sp.sprite.name == "hamburguesa")
            {
                puntosPositivos++;
                Debug.Log("Plato");
            }
            else
            {
                puntosNegativos++;
            }
        }

    }
}

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
    private void Start()
    {
        esto = this.gameObject;
        sp = esto.GetComponent<SpriteRenderer>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Maleta"))
        {
            if(sp.sprite.name == "auriculares")
            {
                puntospos++;
                parada = true;
            }

            if(sp.sprite.name == "camiseta")
            {
                puntospos++;
            }

            if(sp.sprite.name == "cushion-gbe1cbcd51_1280")
            {
                puntosneg++;
            }

            if(sp.sprite.name == "jab�n")
            {
                puntospos++;
            }

            if(sp.sprite.name == "m�vil")
            {
                puntospos++;
            }

            if(sp.sprite.name == "pantal�n")
            {
                puntospos++;
            }

            if(sp.sprite.name == "paraguas")
            {
                puntosneg++;
            }

            if(sp.sprite.name == "peine")
            {
                puntospos++;
            }

            if(sp.sprite.name == "pelota")
            {
                puntosneg++;
            }

            if(sp.sprite.name == "zapatillas")
            {
                puntospos++;
            }
        }
    }
}

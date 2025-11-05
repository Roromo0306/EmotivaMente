using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision_N1_A4 : MonoBehaviour
{
    public GameObject canvas, manager;
    public float puntosEjemplo, puntosActividad;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Canvas_N1_A4 c = canvas.GetComponent<Canvas_N1_A4>();
        Manager_N1_A4 m = manager.GetComponent<Manager_N1_A4>();

        if(c.tipo == 1) // Esto sucede si el modo es el ejemplo
        {
            if (collision.gameObject.CompareTag("Comida_A4"))
            {
                Destroy(collision.gameObject);
                puntosEjemplo += 0.5f;
            }
        }

        if(c.tipo == 2) //Esto sucede si el modo es la actividad
        {
            if (collision.gameObject.CompareTag("Comida_A4"))
            {
                collision.gameObject.SetActive(false);
                puntosActividad += 0.5f;
            }
        }
       
    }
}

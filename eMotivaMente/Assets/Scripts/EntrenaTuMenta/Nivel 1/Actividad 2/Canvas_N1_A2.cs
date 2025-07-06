using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A2 : MonoBehaviour
{
    public Canvas canvas, canvas2;
    public Button Ejemplo, Actividad, Menu, Reintentar;
    public int modo = 0; //Para identificar si activar ejemplo o actividad.

    public GameObject managaer;
    void Start()
    {
        canvas2.enabled = false;
        Time.timeScale = 0;
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        canvas.enabled = true;
    }

    
    void Update()
    {

    }

    private void ejemplo()
    {
        Manager_N1_A2 m = managaer.GetComponent<Manager_N1_A2>();
        canvas.enabled = false;
        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
        modo = 1;
        m.canvas = true;
        Time.timeScale = 1;

        //Activo cusor
        m.cursor = true;

        //Activo el sprite renderer u el collider del generador de ejemplo
        m.generadorEjemploRenderer.enabled = true;
        m.generadorEjemploCollider.enabled = true;
    }

    private void actividad()
    {

    }
}

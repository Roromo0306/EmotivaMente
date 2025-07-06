using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A2 : MonoBehaviour
{
    public Canvas canvas, canvas2, canvasfin;
    public Button Ejemplo, Actividad;

    public GameObject managaer, detector;
    void Start()
    {
        canvas2.enabled = false;
        Time.timeScale = 0;
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        canvas.enabled = true;
        canvasfin.enabled = false;
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
        m.StartCoroutine(m.Act2Ejemplo());
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
        Manager_N1_A2 m = managaer.GetComponent<Manager_N1_A2>();
        Detector_Ejemplo_Col d = detector.GetComponent<Detector_Ejemplo_Col>();

        canvas.enabled = false;
        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
        m.StartCoroutine(m.Act2());
        m.canvas = true;
        Time.timeScale = 1;

        //Activo cusor
        m.cursor = true;

        //Activo el sprite renderer u el collider del generador de ejemplo
        m.generadorEjemploRenderer.enabled = true;
        m.generadorEjemploCollider.enabled = true;

        d.puntosPositivos = 0;
        d.puntosNegativos = 0;
    }
}

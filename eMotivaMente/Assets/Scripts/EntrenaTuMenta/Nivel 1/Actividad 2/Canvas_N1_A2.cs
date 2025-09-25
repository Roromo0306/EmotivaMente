using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A2 : MonoBehaviour
{
    public Canvas canvas, canvas2, canvasfin;
    public Button Ejemplo, Actividad, Audio;

    public GameObject managaer, detector;

    [HideInInspector] public bool empezado;

    public Coroutine corru = null;

    public AudioSource fuenteAudio;
    void Start()
    {
        canvas2.enabled = false;
        Time.timeScale = 0;
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Audio.onClick.AddListener(sonido);
        canvas.enabled = true;
        canvasfin.enabled = false;
        empezado = false;
    }
    private void sonido()
    {
        fuenteAudio.Play();
    }

    private void ejemplo()
    {
        Manager_N1_A2 m = managaer.GetComponent<Manager_N1_A2>();
        canvas.enabled = false;
        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);

        //Paro cualquier corrutina del momento y activo la nueva
        if(corru != null)
        {
            StopCoroutine(corru);
        }
        corru = m.StartCoroutine(m.Act2Ejemplo());

        m.canvas = true;
        Time.timeScale = 1;

        //Activo cusor
        m.cursor = true;
        Cursor.visible = false;

        //Activo el sprite renderer u el collider del generador de ejemplo
        m.generadorEjemploRenderer.enabled = true;
        m.generadorEjemploCollider.enabled = true;
    }

    private void actividad()
    {
        Manager_N1_A2 m = managaer.GetComponent<Manager_N1_A2>();
        Detector_Ejemplo_Col d = detector.GetComponent<Detector_Ejemplo_Col>();

        canvas.enabled = false;
        canvas2.enabled = false; //Desactivo el canvas 2 para que no salgan los textos
        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);

        //Paro cualquier corrutina del momento y activo la nueva
        if (corru != null)
        {
            StopCoroutine(corru);
        }
        corru = m.StartCoroutine(m.Act2());


        m.canvas = true;
        Time.timeScale = 1;

        //Activo cusor. Lo primero es para activar que la imagen siga al cursor y el segundo para desactivar la imagen del cursor
        m.cursor = true;
        Cursor.visible = false;

        //Activo el sprite renderer u el collider del generador de ejemplo
        m.generadorEjemploRenderer.enabled = true;
        m.generadorEjemploCollider.enabled = true;

        d.puntosPositivos = 0;
        d.puntosNegativos = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N2_A1 : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canvas;
    public Canvas canvasFinal;

    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Audio;

    [Header("Gameobjects")]
    public GameObject managaer;
    public GameObject detector;


    [HideInInspector] public bool empezado;
    public Coroutine corru = null;
    public AudioSource fuenteAudio;
    void Start()
    {
        Time.timeScale = 0;
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Audio.onClick.AddListener(sonido);
        canvas.enabled = true;
        canvasFinal.enabled = false;
        empezado = false;
    }

    private void sonido()
    {
        fuenteAudio.Play();
    }

    private void ejemplo()
    {
        Manager_N2_A1 m = managaer.GetComponent<Manager_N2_A1>();
        canvas.enabled = false;
        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);

        //Paro cualquier corrutina del momento y activo la nueva
        if (corru != null)
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
        Manager_N2_A1 m = managaer.GetComponent<Manager_N2_A1>();
        Detector_Colision_N2_A1 d = detector.GetComponent<Detector_Colision_N2_A1>();

        canvas.enabled = false;
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

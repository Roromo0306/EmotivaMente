using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;
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
    public void sonido()
    {
        fuenteAudio.Play();

        //Corrutina. Si se vuelve a pulsar el boton el temporizador se reinicia
        if (coroutineTexto != null)
        {
            StopCoroutine(coroutineTexto);
        }

        coroutineTexto = StartCoroutine(MostrarTextoAudio());
    }

    private IEnumerator MostrarTextoAudio()
    {
        textoAudio.gameObject.SetActive(true);

        yield return new WaitForSeconds(36f);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
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

        //Activo el sprite renderer u el collider del generador de ejemplo
        m.generadorEjemploRenderer.enabled = true;
        m.generadorEjemploCollider.enabled = true;

        d.puntosPositivos = 0;
        d.puntosNegativos = 0;
    }
}

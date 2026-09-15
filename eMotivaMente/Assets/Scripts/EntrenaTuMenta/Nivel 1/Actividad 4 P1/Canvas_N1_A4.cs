using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas_N1_A4 : MonoBehaviour
{
    public Button Ejemplo, Actividad, Audio;
    public Canvas canvas, canvas_ejemplo, canvas_actividad;
    public TextMeshProUGUI text;

    public AudioSource fuenteAudio;
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;
    public float tiempo;

    [HideInInspector] public int tipo = 0;
    
    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Audio.onClick.AddListener(sonido);
        canvas_ejemplo.enabled = false;
        canvas_actividad.enabled = false;
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

        yield return new WaitForSeconds(tiempo);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
    }

    private void ejemplo()
    {
        canvas.enabled = false;
        tipo = 1;

        canvas_ejemplo.enabled = true;
        Time.timeScale = 1;
    }

    private void actividad()
    {
        canvas.enabled = false;
        tipo = 2;
        canvas_actividad.enabled = true;
        Time.timeScale = 1;
    }
}

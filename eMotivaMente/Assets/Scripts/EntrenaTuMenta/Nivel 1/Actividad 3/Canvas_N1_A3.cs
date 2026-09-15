using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A3 : MonoBehaviour
{
    public Button ejemplo, actividad, Audio, BotonSonidos;
    public Canvas canvas, canvasEjemplo;
    public int modo = 0;

    public AudioSource fuenteAudio;
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;
    void Start()
    {
        ejemplo.onClick.AddListener(Ejemplo);
        actividad.onClick.AddListener(Actividad);
        Audio.onClick.AddListener(sonido);
        canvas.enabled = true;
        canvasEjemplo.enabled = false;

        BotonSonidos.enabled = false; //Lo desactivamos

        Time.timeScale = 0;
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

        yield return new WaitForSeconds(42f);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
    }

    private void Ejemplo()
    {
        canvas.enabled = false;
        ejemplo.gameObject.SetActive(false);
        actividad.gameObject.SetActive(false);
        canvasEjemplo.enabled = true; //Esto activa el texto de ejemplo
        BotonSonidos.enabled = true; //Lo activamos
        modo = 1;

        Time.timeScale = 1;
    }

    private void Actividad()
    {
        canvas.enabled = false;
        ejemplo.gameObject.SetActive(false);
        actividad.gameObject.SetActive(false);
        BotonSonidos.enabled = true; //Lo activamos
        modo = 2;
        Time.timeScale = 1;
    }
}

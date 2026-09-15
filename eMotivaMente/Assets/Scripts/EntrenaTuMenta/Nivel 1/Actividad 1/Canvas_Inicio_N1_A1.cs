using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Inicio_N1_A1 : MonoBehaviour
{
    public Button Ejemplo, Actividad, Audio;
    public int modo = 0;
    public Canvas canvas;

    public AudioSource fuenteAudio;
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;

    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Audio.onClick.AddListener(sonido);
        Time.timeScale = 0;
    }

    private void ejemplo()
    {
        modo = 1;
        canvas.enabled = false;
        Time.timeScale = 1;

    }
    private void actividad()
    {
        modo = 2;
        canvas.enabled = false;
        Time.timeScale = 1;
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

        yield return new WaitForSeconds(39f);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
    }
}

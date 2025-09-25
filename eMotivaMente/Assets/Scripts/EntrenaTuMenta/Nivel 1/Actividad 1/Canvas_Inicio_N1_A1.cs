using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Inicio_N1_A1 : MonoBehaviour
{
    public Button Ejemplo, Actividad, Audio;
    public int modo = 0;
    public Canvas canvas;

    public AudioSource fuenteAudio;

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

    private void sonido()
    {
        fuenteAudio.Play();
    }
}

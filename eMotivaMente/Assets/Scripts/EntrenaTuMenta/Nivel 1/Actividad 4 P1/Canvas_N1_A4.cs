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

    [HideInInspector] public int tipo = 0;
    
    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Audio.onClick.AddListener(sonido);
        canvas_ejemplo.enabled = false;
        canvas_actividad.enabled = false;
    }

    private void sonido()
    {
        fuenteAudio.Play();
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

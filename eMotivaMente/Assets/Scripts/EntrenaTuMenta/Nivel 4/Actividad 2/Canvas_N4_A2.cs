using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas_N4_A2 : MonoBehaviour
{
    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;
    public Button Audio;

    [Header("Manager")]
    public GameObject Manager;
    public GameObject gif;


    private int final = 0;

    public AudioSource fuenteAudio;
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;
    public GameObject panel;

    public Canvas canvaIncio;

    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Reintentar.onClick.AddListener(reintentar);
        Menu.onClick.AddListener(menu);
        Audio.onClick.AddListener(sonido);
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
        panel.gameObject.SetActive(true);

        yield return new WaitForSeconds(46f);

        textoAudio.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);

        coroutineTexto = null;
    }

    private void ejemplo()
    {
        Manager_N4_A2 m = Manager.GetComponent<Manager_N4_A2>();

        canvaIncio.enabled = false;
        m.modo = 1;

    }

    private void actividad()
    {
        Manager_N4_A2 m = Manager.GetComponent<Manager_N4_A2>();

        canvaIncio.enabled = false;
        m.modo = 2;
    }

    private void reintentar()
    {
        Manager_N4_A2 m = Manager.GetComponent<Manager_N4_A2>();

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(true);
        Ejemplo.gameObject.SetActive(true);
        gif.gameObject.SetActive(false);
        m.puntuacion = 0;
    }

    private void menu()
    {
        Manager_N4_A2 m = Manager.GetComponent<Manager_N4_A2>();

        Menu_Nivel4.n2 = true;
        //DatosEmotivamente.Instance.puntuacionN1_A5 = m.puntuacion;

        SceneManager.LoadScene("MenuNivel4");


    }
}

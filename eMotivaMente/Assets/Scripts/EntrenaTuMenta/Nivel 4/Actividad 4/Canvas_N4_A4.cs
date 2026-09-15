using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Canvas_N4_A4 : MonoBehaviour
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

        yield return new WaitForSeconds(55f);

        textoAudio.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);

        coroutineTexto = null;
    }

    private void ejemplo()
    {
        Manager_N4_A4 m = Manager.GetComponent<Manager_N4_A4>();

        canvaIncio.enabled = false;
        m.modo = 1;

    }

    private void actividad()
    {
        Manager_N4_A4 m = Manager.GetComponent<Manager_N4_A4>();

        canvaIncio.enabled = false;
        m.modo = 2;
    }

    private void reintentar()
    {
        Manager_N4_A4 m = Manager.GetComponent<Manager_N4_A4>();

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(true);
        Ejemplo.gameObject.SetActive(true);
        gif.gameObject.SetActive(false);
        m.puntuacion = 0;
    }

    private void menu()
    {
        Manager_N4_A4 m = Manager.GetComponent<Manager_N4_A4>();

        Menu_Nivel4.n4 = true;
        //DatosEmotivamente.Instance.puntuacionN1_A5 = m.puntuacion;

        SceneManager.LoadScene("MenuNivel4");


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas_N1_A5 : MonoBehaviour
{
    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;
    public Button Audio;

    [Header("Manager y cronometro")]
    public GameObject Manager;
    public GameObject cronometro;


    private int final = 0;

    public AudioSource fuenteAudio;
    public Canvas canvaIncio;
    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Reintentar.onClick.AddListener(reintentar);
        Menu.onClick.AddListener(menu);
        Audio.onClick.AddListener(sonido);
    }

    private void sonido()
    {
        fuenteAudio.Play();
    }

    private void ejemplo()
    {
        Manager_N1_A5 m = Manager.GetComponent<Manager_N1_A5>();

        canvaIncio.enabled = false;
        m.modo = 1;

    }

    private void actividad()
    {
        Manager_N1_A5 m = Manager.GetComponent<Manager_N1_A5>();
        CronómetroN1_A4 cronos = cronometro.GetComponent<CronómetroN1_A4>();

        cronos.iniciado = true;
        canvaIncio.enabled = false;
        m.modo = 2;
    }

    private void reintentar()
    {
        Manager_N1_A5 m = Manager.GetComponent<Manager_N1_A5>();

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(true);
        Ejemplo.gameObject.SetActive(true);
        m.puntuacion = 0;
    }

    private void menu()
    {
        CronómetroN1_A4 cronos = cronometro.GetComponent<CronómetroN1_A4>();
        Manager_N1_A5 m = Manager.GetComponent<Manager_N1_A5>();

        Menu_Nivel1_Entrena.n5 = true;
        DatosEmotivamente.Instance.tiempoN1_A5 = cronos.Tiempo;
        DatosEmotivamente.Instance.puntuacionN1_A5 = m.puntuacion;

        SceneManager.LoadScene("Menú del nivel 1");


    }
}

using System.Collections;
using System.Collections.Generic;
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

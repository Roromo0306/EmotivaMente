using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas_N4_A5 : MonoBehaviour
{
    public GameObject panelMenu;

    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;

    public Manager_N4_A5 manager;

    public AudioSource fuenteAudio;
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;

    void Start()
    {
        Ejemplo.onClick.AddListener(EjemploF);
        Actividad.onClick.AddListener(ActividadF);
        Reintentar.onClick.AddListener(ReintentarF);
        Menu.onClick.AddListener(MenuF);

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
    }

    void EjemploF()
    {
        panelMenu.SetActive(false);
        manager.IniciarEjemplo();
    }

    void ActividadF()
    {
        panelMenu.SetActive(false);
        manager.IniciarActividad();
    }

    void ReintentarF()
    {
        panelMenu.SetActive(false);
        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);

        manager.Reiniciar();
    }

    void MenuF()
    {
        SceneManager.LoadScene("MenuNivel5");
    }

    public void MostrarResultado(bool mostrarMenu, bool mostrarReintentar)
    {
        panelMenu.SetActive(true);

        Menu.gameObject.SetActive(mostrarMenu);
        Reintentar.gameObject.SetActive(mostrarReintentar);

        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
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

        yield return new WaitForSeconds(43f);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
    }
}
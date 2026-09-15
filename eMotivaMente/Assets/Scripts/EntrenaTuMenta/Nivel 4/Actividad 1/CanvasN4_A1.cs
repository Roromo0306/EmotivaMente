using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasN4_A1 : MonoBehaviour
{
    [Header("Panel Menú")]
    public GameObject panelMenu;

    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;
    public Button Audio;

    [Header("Manager")]
    public ManagerN4_A1 manager;

    public AudioSource fuenteAudio;
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;

    void Start()
    {
        Ejemplo.onClick.AddListener(EjemploF);
        Actividad.onClick.AddListener(ActividadF);
        Reintentar.onClick.AddListener(ReintentarF);
        Menu.onClick.AddListener(MenuF);
        Audio.onClick.AddListener(sonido);

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
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

        yield return new WaitForSeconds(29f);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
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

        manager.ReiniciarActividad();
    }

    void MenuF()
    {
        Menu_Nivel4.n1 = true;
        SceneManager.LoadScene("MenuNivel4");
    }

    // Llamado desde el Manager al finalizar
    public void MostrarMenuFinal(bool mostrarMenu, bool mostrarReintentar)
    {
        panelMenu.SetActive(true);

        Menu.gameObject.SetActive(mostrarMenu);
        Reintentar.gameObject.SetActive(mostrarReintentar);

        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
    }
}

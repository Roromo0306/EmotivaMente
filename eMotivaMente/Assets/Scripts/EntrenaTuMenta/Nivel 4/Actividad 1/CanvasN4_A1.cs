using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasN4_A1 : MonoBehaviour
{
    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;
    public Button Audio;

    [Header("Manager")]
    public GameObject Manager;

    public AudioSource fuenteAudio;
    public Canvas canvaInicio;

    void Start()
    {
        Ejemplo.onClick.AddListener(EjemploF);
        Actividad.onClick.AddListener(ActividadF);
        Reintentar.onClick.AddListener(ReintentarF);
        Menu.onClick.AddListener(MenuF);
        Audio.onClick.AddListener(Sonido);
    }

    private void Sonido()
    {
        fuenteAudio.Play();
    }

    private void EjemploF()
    {
        ManagerN4_A1 m = Manager.GetComponent<ManagerN4_A1>();
        canvaInicio.enabled = false;
        m.modo = 1;
    }

    private void ActividadF()
    {
        ManagerN4_A1 m = Manager.GetComponent<ManagerN4_A1>();
        canvaInicio.enabled = false;
        m.modo = 2;
    }

    private void ReintentarF()
    {
        ManagerN4_A1 m = Manager.GetComponent<ManagerN4_A1>();

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(true);
        Ejemplo.gameObject.SetActive(true);

        m.puntuacion = 0;
        m.errores = 0;
    }

    private void MenuF()
    {
        SceneManager.LoadScene("MenuNivel4");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMenu_N2_A4 : MonoBehaviour
{
    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button MenuPrincipal;
    public Button Audio;

    public AudioSource fuenteAudio;

    [Header("Otros Gameobject")]
    public GameObject manager;
    public Canvas EsteCanvas;


    [HideInInspector] public int modo;

    public void sonido()
    {
        fuenteAudio.Play();
    }
    public void ejemplo()
    {
        modo = 1; //Cambio el valor de modo para que el manager sepa que vamos a entrar en el modo ejemplo
        EsteCanvas.enabled = false; //Desactivo el canvas
        Audio.gameObject.SetActive(false);

        Ejemplo.gameObject.SetActive(false); //Desactivo ejemplo para redirigir al jugador a la actividad cuando acabe
    }

    public void actividad()
    {
        modo = 2; //Cambio el valor de modo para que el manager sepa que vamos a entrar en el modo actividad
        EsteCanvas.enabled = false; //Desactivo el canvas
        Audio.gameObject.SetActive(false);

        //Desactivo los botones de actividad y ejemplo pero activo los de reintentar y menu para que al salir de la actividad el jugador pueda continuar de la manera que desee
        Actividad.gameObject.SetActive(false);
        Ejemplo.gameObject.SetActive(false);
        MenuPrincipal.gameObject.SetActive(true);
        Reintentar.gameObject.SetActive(true);
    }

    public void reintentar()
    {
        SceneManager.LoadScene("Nivel2_Actividad 4"); //Cargo de nuevo la escena
    }

    public void menuPrincipal()
    {
        Manager_N2_A4 man = manager.GetComponent<Manager_N2_A4>();

        DatosEmotivamente.Instance.tiempoN2_A4 = (int)man.Cronometro;

        Menu_Nivel2.n4 = true;
        SceneManager.LoadScene("MenuNivel2"); //Cargo el menu principal
    }
}

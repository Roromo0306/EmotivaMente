using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasMenu_N2_A5 : MonoBehaviour
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

    private void Update()
    {
        Manager_N2_A5 man = manager.GetComponent<Manager_N2_A5>();

        if (man.Terminado) //Comprueba si se ha terminado la actividad
        {
            if(man.score == 19) //Ha acertado todo
            {
                MenuPrincipal.gameObject.SetActive(true);
            }
            else
            {
                if(man.score < 19 && man.score > 3) //Ha tenido fallos
                {
                    MenuPrincipal.gameObject.SetActive(true);
                    Reintentar.gameObject.SetActive(true);
                }
                else
                {
                    if(man.score <= 3) //Ha fallado mucho y debe repetirlo
                    {
                        Reintentar.gameObject.SetActive(true);
                    }
                }
            }
        }
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
    }

    public void reintentar()
    {
        SceneManager.LoadScene("Nivel2_Actividad 5"); //Cargo de nuevo la escena
    }

    public void menuPrincipal()
    {
        Manager_N2_A5 man = manager.GetComponent<Manager_N2_A5>();
        DatosEmotivamente.Instance.puntuacionPosN2_A5 = man.score; //Envio los puntos 

        Menu_Nivel2.n5 = true;
        SceneManager.LoadScene("MenuNivel2"); //Cargo el menu principal
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Canvas_N1_A1 : MonoBehaviour
{

    public Button reintentar, menu;
    public Canvas canvas;
    public TextMeshProUGUI texto2, texto1, texto3; //Textos según la victoria
    public GameObject Manager, generador;
    
    public 
    void Start()
    {
        canvas.enabled = false;
        reintentar.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);

        texto1.gameObject.SetActive(false);
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);

        //Botones de reintentar y menu
        reintentar.onClick.AddListener(reset);
        menu.onClick.AddListener(menuP);
    }


    void Update()
    {
        N1_Actividad1 n = Manager.GetComponent<N1_Actividad1>();
        DetectorColision d = generador.GetComponent<DetectorColision>();

        texto2.text = "Lo has hecho bien, has tenido " + d.puntospos + " puntos y " + d.puntosneg + " fallos. Puedes volver a intentarlo para mejorar o puedes volver al menú para continuar con la siguiente actividad";
      
        //Distintos finales
        if (n.Fase)
        {
            canvas.enabled=true;
            Time.timeScale = 0;
            Cursor.visible = true;
            n.cursorImage.SetActive(false);

            if (n.final == 1) //Final perfecto
            {
                menu.gameObject.SetActive(true);
                texto1.gameObject.SetActive(true);
                Menu_Nivel1_Entrena.n1 = true;
            }

            if (n.final == 2) //Final con fallos
            {
                menu.gameObject.SetActive(true);
                reintentar.gameObject.SetActive(true);
                texto2.gameObject.SetActive(true);
                Menu_Nivel1_Entrena.n1 = true;
            }

            if (n.final == 3) //Final malo
            {
                reintentar.gameObject.SetActive(true);
                texto3.gameObject.SetActive(true);
            }

        }
    }

    //Botón de reseteo
    private void reset()
    {
        SceneManager.LoadScene("N1_Actividad 1");
    }

    //Botón del menú inicial
    private void menuP()
    {
        DetectorColision d = generador.GetComponent<DetectorColision>();

        DatosEmotivamente.Instance.puntuacionPosN1_A1 = d.puntospos; //Envia los puntos positivos al singleton

        //Se asegura que la puntuacion negativa no es 0 antes de enviarla
        if(d.puntospos != 0)
            DatosEmotivamente.Instance.puntuacionNegN1_A1 = d.puntosneg;
        else
            DatosEmotivamente.Instance.puntuacionNegN1_A1 = 0;

        //Carga la escena del nivel 1
        SceneManager.LoadScene("Menú del nivel 1");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasFinal_N2_A1 : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canvasFinal;
    public Canvas canvasPrincipal;

    [Header("Botones")]
    public Button Volver;
    public Button Reintentar;

    [Header("Gameobjects")]
    public GameObject Generador;
    public GameObject manager;

    [Header("Textos")]
    public TextMeshProUGUI texto2;
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto3;
    void Start()
    {
        //Desactivo todo al principio
        Volver.gameObject.SetActive(false);
        Reintentar.gameObject.SetActive(false);
        canvasFinal.enabled = false;

        texto1.gameObject.SetActive(false);
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);

        //Asocio los botones a sus funciones
        Volver.onClick.AddListener(VolverB);
        Reintentar.onClick.AddListener(ReintentarB);
    }

    void Update()
    {
        Detector_Colision_N2_A1 D = Generador.GetComponent<Detector_Colision_N2_A1>();
        Canvas_N2_A1 c = canvasPrincipal.GetComponent<Canvas_N2_A1>();

        texto3.text = "Lo has hecho bien, has tenido " + D.puntosPositivos + " puntos y " + D.puntosNegativos + " fallos. Puedes volver a intentarlo para mejorar o puedes volver al menú para continuar con la siguiente actividad";

        if (c.empezado)
        {
            if (D.puntosPositivos == 13 && D.puntosNegativos == 0)
            {
                //Ha acertado al 100%
                Volver.gameObject.SetActive(true);
                texto1.gameObject.SetActive(true);
                canvasFinal.enabled = true;
            }
            else
            {
                if (D.puntosNegativos == 3 || D.puntosNegativos == 0 && D.puntosPositivos == 0)
                {
                    //Hay que repetirlo
                    Reintentar.gameObject.SetActive(true);
                    texto2.gameObject.SetActive(true);
                    canvasFinal.enabled = true;
                }
                else
                {
                    if (D.puntosPositivos <= 13 && D.puntosNegativos <= 2)
                    {
                        //Esta bien pero con algunos fallos
                        Volver.gameObject.SetActive(true);
                        Reintentar.gameObject.SetActive(true);
                        texto3.gameObject.SetActive(true);
                        canvasFinal.enabled = true;
                    }
                }
            }
        }

    }

    public void VolverB()
    {
        Detector_Colision_N2_A1 D = Generador.GetComponent<Detector_Colision_N2_A1>();

       // DatosEmotivamente.Instance.puntuacionPosN1_A2 = D.puntosPositivos; //Envio los puntos positivos

       /* //Me aseguro que los puntos negativos no son 0 antes de enviarlos
        if (D.puntosNegativos != 0)
            DatosEmotivamente.Instance.puntuacionNegN1_A2 = D.puntosNegativos;
        else
            DatosEmotivamente.Instance.puntuacionNegN1_A2 = 0;*/

        //Cargo el menu
        SceneManager.LoadScene("Menu Nivel 2");
        Menu_Nivel2.n1 = true; 
    }

    public void ReintentarB()
    {
        SceneManager.LoadScene("Nivel2_Actividad 1");
    }
}

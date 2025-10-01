using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class canvasFin : MonoBehaviour
{
    public Canvas canvas, CanvasPrincipal;
    public Button Volver, Reintentar; //Botones de menu y reintentar 
    public GameObject Generador, manager;

    public TextMeshProUGUI texto2, texto1, texto3; //Textos que salen al final
    void Start()
    {
        //Desactivo todo al principio
        Volver.gameObject.SetActive(false);
        Reintentar.gameObject.SetActive(false);
        canvas.enabled = false;

        texto1.gameObject.SetActive(false);
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);

        //Asocio los botones a sus funciones
        Volver.onClick.AddListener(VolverB);
        Reintentar.onClick.AddListener(ReintentarB);
    }
    
    void Update()
    {
        Detector_Ejemplo_Col D = Generador.GetComponent<Detector_Ejemplo_Col>();
        Canvas_N1_A2 c = CanvasPrincipal.GetComponent<Canvas_N1_A2>();

        texto3.text = "Lo has hecho bien, has tenido " + D.puntosPositivos+ " puntos y " + D.puntosNegativos + " fallos. Puedes volver a intentarlo para mejorar o puedes volver al menú para continuar con la siguiente actividad";

        if (c.empezado)
        {
            if (D.puntosPositivos == 11 && D.puntosNegativos == 0)
            {
                //Ha acertado al 100%
                Volver.gameObject.SetActive(true);
                texto1.gameObject.SetActive(true);
                canvas.enabled = true;
                Menu_Nivel1_Entrena.n2 = true;
            }
            else
            {
                if (D.puntosNegativos == 3 || D.puntosNegativos == 0 && D.puntosPositivos == 0)
                {
                    //Hay que repetirlo
                    Reintentar.gameObject.SetActive(true);
                    texto2.gameObject.SetActive(true);
                    canvas.enabled = true;
                }
                else
                {
                    if (D.puntosPositivos <= 11 && D.puntosNegativos <= 2)
                    {
                        //Esta bien pero con algunos fallos
                        Volver.gameObject.SetActive(true);
                        Reintentar.gameObject.SetActive(true);
                        texto3.gameObject.SetActive(true);
                        canvas.enabled = true;
                        Menu_Nivel1_Entrena.n2 = true;
                    }
                }
            }
        }
    }


    private void VolverB()
    {
        Detector_Ejemplo_Col D = Generador.GetComponent<Detector_Ejemplo_Col>();

        DatosEmotivamente.Instance.puntuacionPosN1_A2 = D.puntosPositivos; //Envio los puntos positivos

        //Me aseguro que los puntos negativos no son 0 antes de enviarlos
        if(D.puntosNegativos != 0)
            DatosEmotivamente.Instance.puntuacionNegN1_A2 = D.puntosNegativos;
        else
            DatosEmotivamente.Instance.puntuacionNegN1_A2 = 0;

        //Cargo el menu
        SceneManager.LoadScene("Menú del nivel 1");
    }

    private void ReintentarB()
    {
        SceneManager.LoadScene("N1_Actividad 2");
    }
}

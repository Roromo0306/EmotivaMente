using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class canvasFin : MonoBehaviour
{
    public Canvas canvas, CanvasPrincipal;
    public Button Volver, Reintentar;
    public GameObject Generador, manager;

    public TextMeshProUGUI texto2, texto1, texto3;
    void Start()
    {
        Volver.gameObject.SetActive(false);
        Reintentar.gameObject.SetActive(false);
        canvas.enabled = false;

        texto1.gameObject.SetActive(false);
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);

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
                    //Mal
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
        SceneManager.LoadScene("Menú del nivel 1");
    }

    private void ReintentarB()
    {
        /*Canvas_N1_A1 c = CanvasPrincipal.GetComponent<Canvas_N1_A1>();
        c.canvas.enabled = true;
        canvas.enabled = false;*/
        SceneManager.LoadScene("N1_Actividad 2");
    }
}

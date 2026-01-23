using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasMenu_N2_A2 : MonoBehaviour
{
    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button MenuPrincipal;
    public Button Ayuda;

    [Header("Otros Gameobject")]
    public GameObject detectorColision;
    public GameObject manager;

    [Space]
    public Canvas EsteCanvas;

    [HideInInspector] public int modo;

    [Header("Textos")]
    public TextMeshProUGUI texto2;
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto3;
    public TextMeshProUGUI textoAyuda;
    void Start()
    {
        
    }

    void Update()
    {
        Manager_N2_A2 man = manager.GetComponent<Manager_N2_A2>();
        DetectorColision_N2_A2 dec = detectorColision.GetComponent<DetectorColision_N2_A2>();

        texto3.text = "Lo has hecho bien, has tenido " + dec.puntosPositivos + " puntos y " + dec.puntosNegativos + " fallos. Puedes volver a intentarlo para mejorar o puedes volver al menú para continuar con la siguiente actividad";

        if (man.actTerminada)
        {
            if(dec.puntosPositivos == 20 && dec.puntosNegativos == 0)
            {
                //Has acertado al 100%
                MenuPrincipal.gameObject.SetActive(true);
                texto1.gameObject.SetActive(true);

            }
            else
            {
                if(dec.puntosNegativos == 3 || dec.puntosPositivos == 0 && dec.puntosNegativos == 0)
                {
                    //Hay que repetirlo
                    Reintentar.gameObject.SetActive(true);
                    texto2.gameObject.SetActive(true);
                }
                else
                {
                    if(dec.puntosPositivos <=20 && dec.puntosNegativos <= 2)
                    {
                        //Esta bien pero con algunos fallos
                        MenuPrincipal.gameObject.SetActive(true);
                        Reintentar.gameObject.SetActive(true);
                        texto3.gameObject.SetActive(true);

                    }
                }
            }
        }
    }

    public void ejemplo()
    {
        modo = 1;
        EsteCanvas.enabled = false;
    }

    public void actividad()
    {
        modo = 2;
        EsteCanvas.enabled = false;
    }

    public void reintentar()
    {
        SceneManager.LoadScene("Nivel2_Actividad 2");
    }

    public void menuPrincipal()
    {
        DetectorColision_N2_A2 dec = detectorColision.GetComponent<DetectorColision_N2_A2>();

        DatosEmotivamente.Instance.puntuacionPosN2_A2 = dec.puntosPositivos; //Envio los puntos positivos

        //Me aseguro que los puntos negativos no son 0 antes de enviarlos
        if (dec.puntosNegativos != 0)
            DatosEmotivamente.Instance.puntuacionNegN2_A2 = dec.puntosNegativos;
        else
            DatosEmotivamente.Instance.puntuacionNegN2_A2 = 0;

        Menu_Nivel2.n2 = true;
        SceneManager.LoadScene("MenuNivel2");

    }

    public void ayuda()
    {
        StartCoroutine(texAy());
    }

    IEnumerator texAy()
    {
        textoAyuda.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        textoAyuda.gameObject.SetActive(false);
    }
}

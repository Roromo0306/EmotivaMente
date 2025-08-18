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
    public TextMeshProUGUI texto2, texto1, texto3;
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


        reintentar.onClick.AddListener(reset);
        menu.onClick.AddListener(menuP);
    }


    void Update()
    {
        N1_Actividad1 n = Manager.GetComponent<N1_Actividad1>();
        DetectorColision d = generador.GetComponent<DetectorColision>();

        texto2.text = "Lo has hecho bien, has tenido " + d.puntospos + " puntos y " + d.puntosneg + " fallos. Puedes volver a intentarlo para mejorar o puedes volver al menú para continuar con la siguiente actividad";
      
        
        if (n.Fase)
        {
            canvas.enabled=true;
            Time.timeScale = 0;
            Cursor.visible = true;
            n.cursorImage.SetActive(false);
            if (n.final == 1)
            {
                menu.gameObject.SetActive(true);
                texto1.gameObject.SetActive(true);
                Menu_Nivel1_Entrena.n1 = true;
            }

            if (n.final == 2)
            {
                menu.gameObject.SetActive(true);
                reintentar.gameObject.SetActive(true);
                texto2.gameObject.SetActive(true);
                Menu_Nivel1_Entrena.n1 = true;
            }

            if (n.final == 3)
            {
                reintentar.gameObject.SetActive(true);
                texto3.gameObject.SetActive(true);
            }

        }
    }

    private void reset()
    {
        SceneManager.LoadScene("N1_Actividad 1");
    }

    private void menuP()
    {
        SceneManager.LoadScene("Menú del nivel 1");
    }
}

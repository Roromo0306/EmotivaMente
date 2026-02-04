using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Nivel1_Entrena : MonoBehaviour
{
    [Header("Botones")]
    public Button Sonido;
    public Button N1;
    public Button N2;
    public Button N3;
    public Button N4;
    public Button N5;
    public Button Salida;


    public AudioSource fuenteAudio;

 

    [HideInInspector] public static bool n1 = false, n2= false, n3=false, n4=false, n5=false; 
    void Start()
    {
        Sonido.onClick.AddListener(sonido);
        N1.onClick.AddListener(Nivel1);
        N2.onClick.AddListener(Nivel2);
        N3.onClick.AddListener(Nivel3);
        N4.onClick.AddListener(Nivel4);
        N5.onClick.AddListener(Nivel5);

        Salida.gameObject.SetActive(true);
        Cursor.visible = true;

    }

    void Update()
    {
        if (n1)
        {
            Color c = N1.targetGraphic.color;
            c.a = 138f / 255f;
            N1.targetGraphic.color = c;
        }

        if (n2)
        {
            Color c = N2.targetGraphic.color;
            c.a = 138f / 255f;
            N2.targetGraphic.color = c;
        }

        if (n3)
        {
            Color c = N3.targetGraphic.color;
            c.a = 138f / 255f;
            N3.targetGraphic.color = c;
        }

        if (n4)
        {
            Color c = N4.targetGraphic.color;
            c.a = 138f / 255f;
            N4.targetGraphic.color = c;
        }

        if (n5)
        {
            Color c = N5.targetGraphic.color;
            c.a = 138f / 255f;
            N5.targetGraphic.color = c;
            Salida.gameObject.SetActive(true);
        }
    }

    public void sonido()
    {
        fuenteAudio.Play();
    }

    private void Nivel1()
    {
        SceneManager.LoadScene("N1_Actividad 1");
    }

    private void Nivel2()
    {
        if (n1)
        {
            SceneManager.LoadScene("N1_Actividad 2");
        }
        
    }

    private void Nivel3()
    {
        if (n2)
        {
            SceneManager.LoadScene("N1_Actividad 3");
        }
        
    }

    private void Nivel4()
    {
        if (n3)
        {
            SceneManager.LoadScene("N1_Actividad 4");
        }
        
    }

    private void Nivel5()
    {
        if (n4)
        {
            SceneManager.LoadScene("N1_Actividad 5");
        }
        
    }

    public void CierrePrograma()
    {
        if (DatosEmotivamente.Instance != null)
        {
            DatosEmotivamente.Instance.EnviarDatos();
            Application.Quit();
        }
        else
        {
            Debug.LogWarning("DatosEmotivamente.Instance es null — no se enviaron los datos.");
            Application.Quit();
        }
    }
}

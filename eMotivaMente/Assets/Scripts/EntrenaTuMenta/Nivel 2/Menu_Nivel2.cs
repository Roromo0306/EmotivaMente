using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Nivel2 : MonoBehaviour
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
    public TextMeshProUGUI textoAudio;
    private Coroutine coroutineTexto;

    [HideInInspector] public static bool n1 = false, n2 = false, n3 = false, n4 = false, n5 = false;
    void Start()
    {
        
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

        //Corrutina. Si se vuelve a pulsar el boton el temporizador se reinicia
        if (coroutineTexto != null)
        {
            StopCoroutine(coroutineTexto);
        }

        coroutineTexto = StartCoroutine(MostrarTextoAudio());
    }

    private IEnumerator MostrarTextoAudio()
    {
        textoAudio.gameObject.SetActive(true);

        yield return new WaitForSeconds(13f);

        textoAudio.gameObject.SetActive(false);

        coroutineTexto = null;
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel2_Actividad 1");
    }

    public void Nivel2()
    {
        if (n1)
        {
            SceneManager.LoadScene("Nivel2_Actividad 2");
        }

    }

    public void Nivel3()
    {
        if (n2)
        {
            SceneManager.LoadScene("Nivel2_Actividad 3");
        }

    }

    public void Nivel4()
    {
        if (n3)
        {
            SceneManager.LoadScene("Nivel2_Actividad 4");
        }

    }

    public void Nivel5()
    {
        if (n4)
        {
            SceneManager.LoadScene("Nivel2_Actividad 5");
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

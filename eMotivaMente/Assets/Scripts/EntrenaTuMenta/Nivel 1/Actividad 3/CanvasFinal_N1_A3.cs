using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasFinal_N1_A3 : MonoBehaviour
{
    public Button Menu, Reintentar;
    public GameObject Manager;
    
    void Start()
    {
        Menu.onClick.AddListener(menu);
        Reintentar.onClick.AddListener(reintentar);
    }

    private void reintentar()
    {
        SceneManager.LoadScene("N1_Actividad 3");
    }

    private void menu()
    {
        Botón_N1_A3 bot = Manager.GetComponent<Botón_N1_A3>();

        DatosEmotivamente.Instance.puntuacionPosN1_A3 = bot.aciertos; //Envio los puntos positivos

        //Me aseguro que los puntos negativos no son 0 antes de enviarlos
        if (bot.fallos != 0)
            DatosEmotivamente.Instance.puntuacionNegN1_A3 = bot.fallos;
        else
            DatosEmotivamente.Instance.puntuacionNegN1_A3 = 0;

        Time.timeScale = 1;
        SceneManager.LoadScene("Menú del nivel 1");
    }

}

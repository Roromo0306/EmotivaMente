using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasFinal_N1_A3 : MonoBehaviour
{
    public Button Menu, Reintentar;
    
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
        Time.timeScale = 1;
        SceneManager.LoadScene("Menú del nivel 1");
    }

}

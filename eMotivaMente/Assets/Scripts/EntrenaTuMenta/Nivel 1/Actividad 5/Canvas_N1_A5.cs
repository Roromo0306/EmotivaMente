using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A5 : MonoBehaviour
{
    public Button Ejemplo, Actividad, Reintentar, Menu;
    public GameObject Manager;
    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        Reintentar.onClick.AddListener(reintentar);
        Menu.onClick.AddListener(menu);
    }

    void Update()
    {
        
    }

    private void ejemplo()
    {

    }

    private void actividad()
    {

    }

    private void reintentar()
    {

    }

    private void menu()
    {

    }
}

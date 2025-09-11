using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A5 : MonoBehaviour
{
    public Button Ejemplo, Actividad, Reintentar, Menu;
    public GameObject Manager;

    public Canvas canvaIncio;
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
        Manager_N1_A5 m = Manager.GetComponent<Manager_N1_A5>();

        canvaIncio.enabled = false;
        m.modo = 1;

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

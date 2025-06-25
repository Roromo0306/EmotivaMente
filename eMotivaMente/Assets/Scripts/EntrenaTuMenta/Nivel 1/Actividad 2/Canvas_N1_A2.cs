using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A2 : MonoBehaviour
{
    public Canvas canvas, canvas2;
    public Button Ejemplo, Actividad, Menu, Reintentar;
    public int modo = 0; //Para identificar si activar ejemplo o actividad.
    void Start()
    {
        canvas2.enabled = false;
        Time.timeScale = 0;
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
    }

    
    void Update()
    {
        
    }

    private void ejemplo()
    {
        canvas.enabled = false;
        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
        modo = 1;
    }

    private void actividad()
    {

    }
}

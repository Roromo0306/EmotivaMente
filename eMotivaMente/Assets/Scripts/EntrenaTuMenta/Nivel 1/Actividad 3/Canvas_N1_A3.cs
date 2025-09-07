using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A3 : MonoBehaviour
{
    public Button ejemplo, actividad;
    public Canvas canvas, canvasEjemplo;
    public int modo = 0;
    
    void Start()
    {
        ejemplo.onClick.AddListener(Ejemplo);
        actividad.onClick.AddListener(Actividad);
        canvas.enabled = true;
        canvasEjemplo.enabled = false;
        Time.timeScale = 0;
    }

    
    void Update()
    {
        
    }

    private void Ejemplo()
    {
        canvas.enabled = false;
        ejemplo.gameObject.SetActive(false);
        actividad.gameObject.SetActive(false);
        canvasEjemplo.enabled = true; //Esto activa el texto de ejemplo
        modo = 1;
        Time.timeScale = 1;
    }

    private void Actividad()
    {
        canvas.enabled = false;
        ejemplo.gameObject.SetActive(false);
        actividad.gameObject.SetActive(false);
        modo = 2;
        Time.timeScale = 1;
    }
}

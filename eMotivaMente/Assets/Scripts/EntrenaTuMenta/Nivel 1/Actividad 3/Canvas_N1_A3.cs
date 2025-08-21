using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_N1_A3 : MonoBehaviour
{
    public Button ejemplo, actividad;
    public Canvas canvas;
    void Start()
    {
        ejemplo.onClick.AddListener(Ejemplo);
        actividad.onClick.AddListener(Actividad);
        canvas.enabled = true;
    }

    
    void Update()
    {
        
    }

    private void Ejemplo()
    {
        canvas.enabled = false;
        ejemplo.gameObject.SetActive(false);
        actividad.gameObject.SetActive(false);
    }

    private void Actividad()
    {
        canvas.enabled = false;
        ejemplo.gameObject.SetActive(false);
        actividad.gameObject.SetActive(false);
    }
}

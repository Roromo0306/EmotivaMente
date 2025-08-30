using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Canvas_N1_A4 : MonoBehaviour
{
    public Button Ejemplo, Actividad;
    public Canvas canvas, canvas_ejemplo, canvas_actividad;
    public TextMeshProUGUI text;

    [HideInInspector] public int tipo = 0;
    
    void Start()
    {
        Ejemplo.onClick.AddListener(ejemplo);
        Actividad.onClick.AddListener(actividad);
        canvas_ejemplo.enabled = false;
        canvas_actividad.enabled = false;
    }

    
    void Update()
    {
        
    }

    private void ejemplo()
    {
        canvas.enabled = false;
        tipo = 1;
        canvas_ejemplo.enabled = true;
    }

    private void actividad()
    {
        canvas.enabled = false;
        tipo = 2;
        canvas_actividad.enabled = true;
    }
}

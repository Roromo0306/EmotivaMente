using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager_N1_A5 : MonoBehaviour
{
    [HideInInspector] public int modo = 0;
    private bool para = false, empezar = false;

    public List<Sprite> ejemplo;
    public Sprite rojo, ambar, verde;
    public Image ej, act;

    public Canvas canvaIncio;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (modo == 1) //Modo Ejemplo
        {
            if (!empezar)
            {
                empezar = true;
            }
        }

        if(modo == 2) //Modo Actividad
        {
            if(!para)
            {
                empezar = true;
            }
        }
    }

    public void ejemploF()
    {
        int cont = 0;
        
        ej.sprite = ejemplo[cont];

        if (cont >= 4)
        {
            cont = 0;
            modo = 0;
            canvaIncio.enabled = true;
        }
    }

}

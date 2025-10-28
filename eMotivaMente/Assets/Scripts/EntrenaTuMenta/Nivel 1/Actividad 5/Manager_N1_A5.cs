using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager_N1_A5 : MonoBehaviour
{
    [HideInInspector] public int modo = 0;
    private bool para = false, empezar = false;

    public List<Sprite> ejemplo;
    public List<Sprite> actividad;
    public Sprite rojo, ambar, verde;
    public Image ej, act;

    public Canvas canvaIncio;

    [Header("Botones rojo, ambar y verde")]
    public Button Rojo;
    public Button Ambar;
    public Button Verde;

    private bool presionado = false; //Bool para saber si se ha presionado alg�n bot�n
    public int cont = 0;
    public int puntuacion;
    public GameObject cronometro;
    void Start()
    {
        Rojo.onClick.AddListener(BotonRojo);
        Ambar.onClick.AddListener(BotonAmbar);
        Verde.onClick.AddListener(BotonVerde);

        ej.gameObject.SetActive(false);
        act.gameObject.SetActive(false);

        StopAllCoroutines();
    }

    
    void Update()
    {
        if (modo == 1) //Modo Ejemplo
        {
            if (!empezar)
            {
                empezar = true;
                ej.gameObject.SetActive(true);
                StartCoroutine(ejemploF());
            }
        }

        if(modo == 2) //Modo Actividad
        {
            if(!para)
            {
                empezar = true;
                act.gameObject.SetActive(true);
                StartCoroutine(actividadF());
            }
        }
    }

    //Funciones Botones Rojo, Ambar y Verde
    private void BotonRojo()
    {
        //Ejemplo
        if(modo == 1)
        {
            if(ej.sprite.name == "sem�foro verde")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if(modo == 2)
        {
            if (act.sprite.name == "sem�foro verde")
            {
                presionado = true;
                puntuacion++;
                cont++;
            }
            else
            {
                presionado = true;
                cont++;
            }
        }
    }
    
    private void BotonAmbar()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "sem�foro �mbar")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "sem�foro �mbar")
            {
                presionado = true;
                puntuacion++;
                cont++;
            }
            else
            {
                presionado = true;
                cont++;
            }
        }
    }

    private void BotonVerde()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "sem�foro rojo")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "sem�foro rojo")
            {
                presionado = true;
                puntuacion++;
                cont++;
            }
            else
            {
                presionado = true;
                cont++;
            }
        }
    }

    //Corrutinas del ejemplo y la actividad
    IEnumerator ejemploF()
    {
        while(cont < ejemplo.Count)
        {
            ej.sprite = ejemplo[cont];
            presionado = false;

            yield return new WaitUntil(() => presionado);

            yield return null; //Permite que la UI se actualice antes 
        }
        
        
        cont = 0;
        modo = 0;
        ej.gameObject.SetActive(false);
        canvaIncio.enabled = true;
        empezar = false;
        yield break;
        
    }


    IEnumerator actividadF()
    {
        Canvas_N1_A5 canva = canvaIncio.GetComponent<Canvas_N1_A5>();
        Cron�metroN1_A4 cronos = cronometro.GetComponent<Cron�metroN1_A4>();

        while (cont < actividad.Count)
        {
            act.sprite = actividad[cont];
            presionado = false;

            yield return new WaitUntil(() => presionado);

            yield return null;
        }

        cont = 0;
        modo = 0;
        cronos.iniciado = false;
        act.gameObject.SetActive(false);

        if(puntuacion == 10) //Perfecto
        {
            canva.Menu.gameObject.SetActive(true);
            canva.Actividad.gameObject.SetActive(false);
            canva.Ejemplo.gameObject.SetActive(false);

            canvaIncio.enabled = true;
            empezar = false;
            puntuacion = 0;
        }

        if(puntuacion <= 9 && puntuacion >= 4) //Algunos fallos
        {
            canva.Menu.gameObject.SetActive(true);
            canva.Reintentar.gameObject.SetActive(true);
            canva.Actividad.gameObject.SetActive(false);
            canva.Ejemplo.gameObject.SetActive(false);

            canvaIncio.enabled = true;
            empezar = false;
            puntuacion = 0;
        }

        if(puntuacion <= 3) //Repetir
        {
            canva.Reintentar.gameObject.SetActive(true);
            canva.Actividad.gameObject.SetActive(false);
            canva.Ejemplo.gameObject.SetActive(false);

            canvaIncio.enabled = true;
            empezar = false;
            puntuacion = 0;
        }

        yield break;
    }
}

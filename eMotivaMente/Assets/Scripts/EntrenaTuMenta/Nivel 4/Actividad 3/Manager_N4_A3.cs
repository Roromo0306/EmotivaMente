using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager_N4_A3 : MonoBehaviour
{
    [HideInInspector] public int modo = 0;
    private bool para = false, empezar = false;

    public List<Sprite> ejemplo;
    public List<Sprite> actividad;
    public Sprite bocadillo;
    public List<TextMeshProUGUI> textos;
    public Image ej, act;
    public TextMeshProUGUI TEjem, TActi;

    public Canvas canvaIncio;

    [Header("Botones rojo, ambar y verde")]
    public Button Flecha;
    public Button Ojo;
    public Button NoPasar;

    private bool presionado = false; //Bool para saber si se ha presionado algún botón
    public int cont = 0;
    public int puntuacion;

    void Start()
    {
        Flecha.onClick.AddListener(BotonFlecha);
        Ojo.onClick.AddListener(BotonOjo);
        NoPasar.onClick.AddListener(BotonNoPasar);

        ej.gameObject.SetActive(false);
        act.gameObject.SetActive(false);
        TEjem.gameObject.SetActive(false);
        TActi.gameObject.SetActive(false);

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
                TEjem.gameObject.SetActive(true);
                StartCoroutine(ejemploF());
            }
        }

        if (modo == 2) //Modo Actividad
        {
            if (!para)
            {
                para = true;
                act.gameObject.SetActive(true);
                TActi.gameObject.SetActive(true);
                StartCoroutine(actividadF());
            }
        }
    }

    //Funciones Botones de la tarjeta, flecha y monedas
    private void BotonFlecha()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "TextoBueno")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "TextoBueno")
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

    private void BotonOjo()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "TextoIgnorar")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "TextoIgnorar")
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

    private void BotonNoPasar()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "TextoNoColar")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "TextoNoColar")
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
        while (cont < ejemplo.Count)
        {
            ej.sprite = ejemplo[cont];
            TEjem.text = textos[cont].text;
            presionado = false;

            yield return new WaitUntil(() => presionado);

            yield return null; //Permite que la UI se actualice antes 
        }


        cont = 0;
        modo = 0;
        ej.gameObject.SetActive(false);
        TEjem.gameObject.SetActive(false);
        canvaIncio.enabled = true;
        empezar = false;
        yield break;

    }

    //Corrutina de la actividad que hace que los semaforos avancen conforme pulsas los botones. Tambien controla las condiciones de victoria
    IEnumerator actividadF()
    {
        Canvas_N4_A3 canva = canvaIncio.GetComponent<Canvas_N4_A3>();

        while (cont < actividad.Count)
        {
            act.sprite = actividad[cont];
            TActi.text = textos[cont].text;
            presionado = false;

            yield return new WaitUntil(() => presionado); //La corrutina no avanza hasta que presionado sea true

            yield return null;
        }

        cont = 0;
        modo = 0;
        act.gameObject.SetActive(false);
        TActi.gameObject.SetActive(false);

        //Condiciones de victoria
        if (puntuacion == 10) //Perfecto
        {
            canva.Menu.gameObject.SetActive(true);
            canva.Actividad.gameObject.SetActive(false);
            canva.Ejemplo.gameObject.SetActive(false);

            canvaIncio.enabled = true;
            para = false;
            puntuacion = 0;
        }

        if (puntuacion <= 9 && puntuacion >= 4) //Algunos fallos
        {
            canva.Menu.gameObject.SetActive(true);
            canva.Reintentar.gameObject.SetActive(true);
            canva.Actividad.gameObject.SetActive(false);
            canva.Ejemplo.gameObject.SetActive(false);
            canvaIncio.enabled = true;
            para = false;
            puntuacion = 0;

        }

        if (puntuacion <= 3) //Repetir
        {
            canva.Reintentar.gameObject.SetActive(true);
            canva.Actividad.gameObject.SetActive(false);
            canva.Ejemplo.gameObject.SetActive(false);

            canvaIncio.enabled = true;
            para = false;
            puntuacion = 0;
        }

        yield break;
    }
}

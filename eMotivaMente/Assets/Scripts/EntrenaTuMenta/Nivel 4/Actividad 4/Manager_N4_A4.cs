using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N4_A4 : MonoBehaviour
{
    [HideInInspector] public int modo = 0;
    private bool para = false, empezar = false;

    public List<Sprite> ejemplo;
    public List<Sprite> actividad;
    public Sprite sprint, correr, andar, parado;
    public Image ej, act;

    public Canvas canvaIncio;

    [Header("Botones")]
    public Button Correr;
    public Button Andar;
    public Button Sprint;
    public Button Parado;

    private bool presionado = false; //Bool para saber si se ha presionado algún botón
    public int cont = 0;
    public int puntuacion;

    void Start()
    {
        Correr.onClick.AddListener(BotonCorrer);
        Andar.onClick.AddListener(BotonAndar);
        Sprint.onClick.AddListener(BotonSprint);
        Parado.onClick.AddListener(BotonParado);

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

        if (modo == 2) //Modo Actividad
        {
            if (!para)
            {
                para = true;
                act.gameObject.SetActive(true);
                StartCoroutine(actividadF());
            }
        }
    }

    //Funciones Botones de la tarjeta, flecha y monedas
    private void BotonCorrer()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "Parado")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "Parado")
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

    private void BotonAndar()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "Sprint")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "Sprint")
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

    private void BotonSprint()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "Andar")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "Andar")
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

    private void BotonParado()
    {
        //Ejemplo
        if (modo == 1)
        {
            if (ej.sprite.name == "Correr")
            {
                presionado = true;
                cont++;
            }
        }

        //Actividad
        if (modo == 2)
        {
            if (act.sprite.name == "Correr")
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

    //Corrutina de la actividad que hace que los semaforos avancen conforme pulsas los botones. Tambien controla las condiciones de victoria
    IEnumerator actividadF()
    {
        Canvas_N4_A4 canva = canvaIncio.GetComponent<Canvas_N4_A4>();

        while (cont < actividad.Count)
        {
            act.sprite = actividad[cont];
            presionado = false;

            yield return new WaitUntil(() => presionado); //La corrutina no avanza hasta que presionado sea true

            yield return null;
        }

        cont = 0;
        modo = 0;
        act.gameObject.SetActive(false);

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

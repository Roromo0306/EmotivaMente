using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N1_A4_2 : MonoBehaviour
{
    public GameObject Canvas;
    [HideInInspector] public bool activado = false;

    [Space]
    [Header("Listas para el ejemplo")]
    public List<Button> cuadrados_ejemplo;
    public List<Image> Comida_ejemplo;

    [Space]
    [Header("Listas para la actividad")]
    public List<Button> cuadrados_actividad;
    public List<Image> Comida_actividad;

    [Space]
    private int baldosa = 0;
    [HideInInspector] public string nombre1, nombre2;

    public float segundosEspera = 1f; //El tiempo que espera antes de resetear

    [HideInInspector] public Image imagen1, imagen2;
    [HideInInspector] public Button cuadrado1, cuadrado2;

    [Header("Gameobjects cestas y cronometros")]
    public GameObject cesta_ejemplo;
    public GameObject cesta_actividad;
    public GameObject cronometro;

    [Header("Canvas")]
    public Canvas canvas_ejemplo;
    public Canvas canvas_actividad;
    public Canvas canvasFinal;
    void Start()
    {
        canvasFinal.enabled = false;
    }

   
    void Update()
    {
        Canvas_N1_A4 c = Canvas.GetComponent<Canvas_N1_A4>();
        colision_N1_A4 colE = cesta_ejemplo.GetComponent<colision_N1_A4>();
        colision_N1_A4 colA = cesta_actividad.GetComponent<colision_N1_A4>();
        CronómetroN1_A4 crono = cronometro.GetComponent<CronómetroN1_A4>();

        //Ejemplo
        if (c.tipo == 1)
        {
            if (!activado)
            {
                EmpezarEjemplo();
            }

            if (colE.puntosEjemplo == 2)
            {
                finalE();
            }
        }

        //Actividad
        if(c.tipo == 2)
        {
            if (!activado)
            {
                EmpezarActividad();
            }

            if (colA.puntosActividad == 8)
            {
                crono.iniciado = false;
                finalA();
            }
        }
    }

    //Inicia el ejemplo
    private void EmpezarEjemplo()
    {
        activado = true;

        int cant = Mathf.Min(cuadrados_ejemplo.Count, Comida_ejemplo.Count); //Lo que hace es contar los elementos de cada lista y se queda con el más pequeño

        for (int i = 0; i < cant; i++)
        {
            Button bt = cuadrados_ejemplo[i];

            int index = i;
            
            bt.onClick.RemoveAllListeners();
            bt.onClick.AddListener(() => Mostrar_Ejemplo(index));

        }
    }

    //Inicia la actividad
    private void EmpezarActividad()
    {
        CronómetroN1_A4 crono = cronometro.GetComponent<CronómetroN1_A4>();


        activado = true;
        crono.iniciado = true;
        int cant = Mathf.Min(cuadrados_actividad.Count, Comida_actividad.Count);

        for (int i = 0; i < cant; i++)
        {
            Button bt = cuadrados_actividad[i];

            int index = i;

            bt.onClick.RemoveAllListeners();
            bt.onClick.AddListener(() => Mostrar_Actividad(index));

        }
    }

    //Esta función se encarga de mostrar los cuadrados y sus imágenes
    private void Mostrar_Ejemplo(int i)
    {
        Button bt = cuadrados_ejemplo[i];
        Image img = Comida_ejemplo[i];

        if (baldosa < 2)
        {


            if (bt != null)
                bt.gameObject.SetActive(false);

            img.gameObject.SetActive(true);

            if(baldosa == 0)
            {
                nombre1 = img.name;
                imagen1 = Comida_ejemplo[i];
            }

            if(baldosa == 1)
            {
                nombre2 = img.name;
                imagen2 = Comida_ejemplo[i];
            }

                baldosa++;
        }

        if (baldosa == 2 && nombre1 != null && nombre2 != null)
        {
            if (nombre1 != nombre2)
            {
                Debug.Log("Pareja");

                LlevarObjeto llevarImagen1 = imagen1.GetComponent<LlevarObjeto>();
                LlevarObjeto llevarImagen2 = imagen2.GetComponent<LlevarObjeto>();

                llevarImagen1.activado = true;
                llevarImagen2.activado = true;

                baldosa = 0;
                nombre1 = nombre2 = null;
                imagen1 = null;
                imagen2 = null;
            }
            
            if(nombre1  == nombre2)
            {
                StartCoroutine(Reseteo());
            }
        }
        
    }

    //Esta función se encarga de mostrar los cuadrados y sus imágenes
    private void Mostrar_Actividad(int i)
    {
        Button bt = cuadrados_actividad[i];
        Image img = Comida_actividad[i];

        if (baldosa < 2)
        {


            if (bt != null)
                bt.gameObject.SetActive(false);

            img.gameObject.SetActive(true);

            if (baldosa == 0)
            {
                nombre1 = img.name;
                imagen1 = Comida_actividad[i];
                cuadrado1 = cuadrados_actividad[i];
            }

            if (baldosa == 1)
            {
                nombre2 = img.name;
                imagen2 = Comida_actividad[i];
                cuadrado2 = cuadrados_actividad[i];
            }

            baldosa++;
        }

        if (baldosa == 2 && nombre1 != null && nombre2 != null)
        {
            if (nombre1 != nombre2)
            {
                Debug.Log("Pareja");

                LlevarObjeto llevarImagen1 = imagen1.GetComponent<LlevarObjeto>();
                LlevarObjeto llevarImagen2 = imagen2.GetComponent<LlevarObjeto>();

                llevarImagen1.activado = true;
                llevarImagen2.activado = true;

                baldosa = 0;
                nombre1 = nombre2 = null;
                imagen1 = null;
                imagen2 = null;
                cuadrado1 = cuadrado2 = null;
            }

            if (nombre1 == nombre2)
            {
                StartCoroutine(ReseteoA());
            }
        }

    }

    //Sirve para resetear cuando no se forme una pareja
    private IEnumerator Reseteo()
    {
        yield return new WaitForSeconds(segundosEspera);

        int cant = Mathf.Min(cuadrados_ejemplo.Count, Comida_ejemplo.Count); //Lo que hace es contar los elementos de cada lista y se queda con el más pequeño

        for (int i = 0; i < cant; i++)
        {
            cuadrados_ejemplo[i].gameObject.SetActive(true);
            Comida_ejemplo[i].gameObject.SetActive(false);
            nombre1 = null;
            nombre2 = null;
            baldosa = 0;

            imagen1 = null;
            imagen2 = null;

        }
    }

    private IEnumerator ReseteoA()
    {
        Debug.Log("Hola");
        yield return new WaitForSeconds(segundosEspera);

        int cant = Mathf.Min(cuadrados_actividad.Count, Comida_actividad.Count); //Lo que hace es contar los elementos de cada lista y se queda con el más pequeño

        /*for (int i = 0; i < cant; i++)
        {
            cuadrados_actividad[i].gameObject.SetActive(true);
            Comida_actividad[i].gameObject.SetActive(false);
        }*/

        imagen1.gameObject.SetActive(false);
        imagen2.gameObject.SetActive(false);
        cuadrado1.gameObject.SetActive(true);
        cuadrado2.gameObject.SetActive(true);

        nombre1 = null;
        nombre2 = null;
        baldosa = 0;

        imagen1 = null;
        imagen2 = null;
        cuadrado1 = cuadrado2 = null;
    }

    //Final del ejemplo
    private void finalE()
    {
        Canvas_N1_A4 c = Canvas.GetComponent<Canvas_N1_A4>();
        colision_N1_A4 colE = cesta_ejemplo.GetComponent<colision_N1_A4>();

        c.tipo = 0;
        colE.puntosEjemplo = 0;
        c.canvas.enabled = true;
        canvas_ejemplo.enabled = false;

    }

    //Final de la actividad
    private void finalA()
    {
        Canvas_N1_A4 c = Canvas.GetComponent<Canvas_N1_A4>();
        colision_N1_A4 colA = cesta_actividad.GetComponent<colision_N1_A4>();

        c.tipo = 0;
        colA.puntosActividad = 0;
        canvas_actividad.enabled = false;
        canvasFinal.enabled = true;
    }
}

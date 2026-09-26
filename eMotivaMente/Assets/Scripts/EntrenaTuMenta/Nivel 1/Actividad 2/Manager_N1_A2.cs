using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Runtime.ExceptionServices;
//using Microsoft.Unity.VisualStudio.Editor;

public class Manager_N1_A2 : MonoBehaviour
{
    public Canvas canva, canva2, canvaFin;

    public List<Sprite> sprite_ejemplo, sprite_actividad;
    public TextMeshProUGUI texto1, texto2, texto3;
    public GameObject generador_ejemplo;


    [Header("Escalas")]
    public List<Vector3> escalasActividad = new List<Vector3>
    {
    new Vector3(0.19f, 0.19f, 0.19f), // Queso
    new Vector3(0.20f, 0.20f, 0.20f), // Manzana
    new Vector3(0.52f, 0.52f, 0.52f), // Piano
    new Vector3(0.13f, 0.13f, 0.13f), // Fresa
    new Vector3(0.18f, 0.18f, 0.18f), // Zanahoria
    new Vector3(0.52f, 0.52f, 0.52f), // Piano2
    new Vector3(0.37f, 0.37f, 0.37f), // Armario
    new Vector3(0.23f, 0.23f, 0.23f), // Pan
    new Vector3(0.36f, 0.36f, 0.36f), // Armario2
    new Vector3(0.17f, 0.17f, 0.17f), // Pescado
    new Vector3(0.41f, 0.41f, 0.41f), // Cerezas
    new Vector3(0.13f, 0.13f, 0.13f), // Sacacorchos
    new Vector3(0.58f, 0.58f, 0.58f), // Hamburguesas
    new Vector3(0.64f, 0.64f, 0.64f), // Árbol
    new Vector3(0.47f, 0.47f, 0.47f), // Botella
    new Vector3(0.33f, 0.33f, 0.33f)  // Tijera
    };

    [Header("Escalas ejemplo")]
    public List<Vector3> escalasEjemplo = new List<Vector3>
    {
    new Vector3(0.33f, 0.33f, 0.33f), // Tijera
    new Vector3(0.64f, 0.64f, 0.64f), // Árbol
    new Vector3(0.43f, 0.43f, 0.43f)  // Pera
    };

    [HideInInspector] public SpriteRenderer generadorEjemploRenderer;
    [HideInInspector] public Collider2D generadorEjemploCollider;
    private Vector3 originalPositionEjemplo;

    public bool isDragging = false;
    private Vector3 offset;

    private BoxCollider2D boxCollider;

    public int fase = 0, faseAct =0;
    public bool Fase = false, canvas =false;


    void Start()
    {
        Canvas_N1_A2 can = canva.GetComponent<Canvas_N1_A2>();

        // Obtiene componentes
        generadorEjemploRenderer = generador_ejemplo.GetComponent<SpriteRenderer>();
        generadorEjemploCollider = generador_ejemplo.GetComponent<Collider2D>();

        // Guarda posición original del generador
        originalPositionEjemplo = generador_ejemplo.transform.position;
        
        boxCollider = generador_ejemplo.GetComponent<BoxCollider2D>();
        Time.timeScale = 1;

        canva2.enabled = true;
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);
        texto1.gameObject.SetActive(false);

        generadorEjemploRenderer.enabled = false;
        generadorEjemploCollider.enabled = false;   

    }

   
    void Update()
    {
        Detector_Ejemplo_Col gen_ejemplo = generador_ejemplo.GetComponent<Detector_Ejemplo_Col>();
        Canvas_N1_A2 can = canva.GetComponent<Canvas_N1_A2>();
        canvasFin canFin = canvaFin.GetComponent<canvasFin>();

        //Actualiza posición del cursor personalizado
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;

        // Detecta clic inicial
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);

            if (hit == generadorEjemploCollider)
            {
                isDragging = true;
                offset = generador_ejemplo.transform.position - mouseWorld;
            }
        }


        // Control de colisiones y arrastre
        if (!gen_ejemplo.parada)
        {
            if (isDragging)
            {
                generador_ejemplo.transform.position = mouseWorld + offset;
                boxCollider.enabled = false;
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                boxCollider.enabled = true;
                isDragging = false;
            }
        }


        //Con este if lo que controlo es que si se detecta una colision entre la
        //caja o el playo y el sprite, el jugador ya no puede coger el objeto hasta que cambie
        if (gen_ejemplo.parada)
            {

            }
            else
            {

                if (isDragging) //Arrastrar el sprite
                {
                    generador_ejemplo.transform.position = mouseWorld + offset;
                    boxCollider.enabled = false;
                }


                if (Input.GetMouseButtonUp(0) && isDragging) //Suelto el sprite
                {
                    boxCollider.enabled = true;
                    isDragging = false;
                }
            }
        

    

        //Condiconales para la activacion de los textos
        if (canvas)
        {
            texto1.gameObject.SetActive(true);
            texto2.gameObject.SetActive(false);
            texto3.gameObject.SetActive(false);

        }
        if (fase == 2)
        {
            canvas = false;
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(true);
            texto3.gameObject.SetActive(false);
        }
        if (fase == 3)
        {
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(false);
            texto3.gameObject.SetActive(true);
        }
        if (fase == 4)
        {
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(false);
            texto3.gameObject.SetActive(false);

            //Vuelta al canvas

            Time.timeScale = 0; //Devuelvo el tiempo a 0
            can.canvas.enabled = true; //Activo el canvas
            can.Ejemplo.gameObject.SetActive(true);
            can.Actividad.gameObject.SetActive(true);

            generadorEjemploCollider.enabled = false; //Deshabilito el colider y el renderer del generador de ejemplo
            generadorEjemploRenderer.enabled = false;
            fase = 0; //Vuelvo a poner la fase en 0
        }

        //Condición de fin al terminar la actividad principal
        if (faseAct == 17)
        {
            Time.timeScale = 0; //Devuelvo el tiempo a 0
            canFin.canvas.enabled = true; //Activo el canvas final

            generadorEjemploCollider.enabled = false; //Desabilito el colider y el renderer del generador de ejemplo
            generadorEjemploRenderer.enabled = false;
            fase = 0; //Vuelvo a poner la fase en 0

            can.empezado = true;
        }


    }

    //Corrutina del ejemplo
    public IEnumerator Act2Ejemplo()
    {
        Detector_Ejemplo_Col gen_ejemplo = generador_ejemplo.GetComponent<Detector_Ejemplo_Col>();
        Canvas_N1_A2 can = canva.GetComponent<Canvas_N1_A2>();

        while (true)
        {
            for (int i = 0; i < sprite_ejemplo.Count; i++)
            {
                gen_ejemplo.parada = false;

                // Cambiar sprite
                generadorEjemploRenderer.sprite = sprite_ejemplo[i];

                // Restaurar posición
                generador_ejemplo.transform.position = originalPositionEjemplo;

                // Cambiar escala
                generador_ejemplo.transform.localScale = escalasEjemplo[i];

                fase++;

                yield return new WaitForSeconds(5f);
            }
        }
    }

    //Corrutina de la actividad
    public IEnumerator Act2()
    {
        Detector_Ejemplo_Col gen_ejemplo = generador_ejemplo.GetComponent<Detector_Ejemplo_Col>();
        Canvas_N1_A2 can = canva.GetComponent<Canvas_N1_A2>();

        while (true)
        {
            for (int i = 0; i < sprite_actividad.Count; i++)
            {
                gen_ejemplo.parada = false;

                // Cambiar sprite
                generadorEjemploRenderer.sprite = sprite_actividad[i];

                // Restaurar posición
                generador_ejemplo.transform.position = originalPositionEjemplo;

                // Cambiar escala
                generador_ejemplo.transform.localScale = escalasActividad[i];

                faseAct++;

                yield return new WaitForSeconds(5f);
            }
        }
    }

}

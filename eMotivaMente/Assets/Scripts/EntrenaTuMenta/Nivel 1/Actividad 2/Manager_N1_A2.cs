using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;

public class Manager_N1_A2 : MonoBehaviour
{
    public Canvas canva, canva2, canvaFin;

    public List<Sprite> sprite_ejemplo, sprite_actividad;
    public TextMeshProUGUI texto1, texto2, texto3;
    public GameObject generador_ejemplo;

    public GameObject cursorImage;

    [HideInInspector] public SpriteRenderer generadorEjemploRenderer;
    [HideInInspector] public Collider2D generadorEjemploCollider;
    private Vector3 originalPositionEjemplo;

    public bool isDragging = false;
    private Vector3 offset;

    private BoxCollider2D boxCollider;

    public int fase = 0, faseAct =0;
    public bool Fase = false, canvas =false;

    [HideInInspector] public bool cursor = false;

    void Start()
    {
        Canvas_N1_A2 can = canva.GetComponent<Canvas_N1_A2>();

        // Oculta cursor del sistema
        Cursor.visible = false;

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
        if (cursor)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;
            cursorImage.transform.position = mouseWorld;

            //Detecta clic inicial
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D hit = Physics2D.OverlapPoint(mouseWorld);
                if (hit == generadorEjemploCollider)
                {
                    isDragging = true;
                    offset = generador_ejemplo.transform.position - mouseWorld;
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

            generadorEjemploCollider.enabled = false; //Desabilito el colider y el renderer del generador de ejemplo
            generadorEjemploRenderer.enabled = false;
            fase = 0; //Vuelvo a poner la fase en 0
            cursor = false; //Desactivo cursor
        }

        //Condición de fin al terminar la actividad principal
        if (faseAct == 17)
        {
            Time.timeScale = 0; //Devuelvo el tiempo a 0
            canFin.canvas.enabled = true; //Activo el canvas final

            generadorEjemploCollider.enabled = false; //Desabilito el colider y el renderer del generador de ejemplo
            generadorEjemploRenderer.enabled = false;
            fase = 0; //Vuelvo a poner la fase en 0
            cursor = false; //Desactivo cursor
        }


    }

    //Corrutina del ejemplo
    public IEnumerator Act2Ejemplo()
    {
        Detector_Ejemplo_Col gen_ejemplo = generador_ejemplo.GetComponent<Detector_Ejemplo_Col>();
        while (true)
        {
            foreach (var sprite in sprite_ejemplo)
            {
                gen_ejemplo.parada = false;
                generadorEjemploRenderer.sprite = sprite;
                generador_ejemplo.transform.position = originalPositionEjemplo;

                fase++;
                yield return new WaitForSeconds(10f);


            }
        }
    }

    //Corrutina de la actividad
    public IEnumerator Act2()
    {
        Detector_Ejemplo_Col gen_ejemplo = generador_ejemplo.GetComponent<Detector_Ejemplo_Col>();
        while (true)
        {
            foreach (var sprite in sprite_actividad)
            {
                gen_ejemplo.parada = false;
                generadorEjemploRenderer.sprite = sprite;
                generador_ejemplo.transform.position = originalPositionEjemplo;

                faseAct++;
                yield return new WaitForSeconds(7f);


            }
        }
    }

}

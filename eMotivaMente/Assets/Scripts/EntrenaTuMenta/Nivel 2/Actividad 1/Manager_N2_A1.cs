using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N2_A1 : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canva;
    public Canvas canva2;
    public Canvas canvaFin;

    [Header("Listas")]
    public List<Sprite> sprite_ejemplo;
    public List<Sprite> sprite_actividad;

    [Space]
    public GameObject generador;

    [Header("Imagen Cursor Raton")]
    public GameObject cursorImage;

    [HideInInspector] public Image generadorEjemploRenderer;
    [HideInInspector] public Collider2D generadorEjemploCollider;
    private Vector3 originalPositionEjemplo;

    [HideInInspector] public bool isDragging = false;
    private Vector3 offset;

    private BoxCollider2D boxCollider;
    private RectTransform cursorRect;

    [HideInInspector] public int fase = 0, faseAct = 0;
    [HideInInspector] public bool Fase = false, canvas = false;
    [HideInInspector] public bool cursor = false;

    void Start()
    {
        Canvas_N2_A1 can = canva.GetComponent<Canvas_N2_A1>();

        cursor = false; //Desactivo cursor
        Cursor.visible = true; //Activo el cursor para que se vea

        // Obtiene componentes
        generadorEjemploRenderer = generador.GetComponent<Image>();
        generadorEjemploCollider = generador.GetComponent<Collider2D>();
        cursorRect = cursorImage ? cursorImage.GetComponent<RectTransform>() : null;

        // Guarda posición original del generador
        originalPositionEjemplo = generador.transform.position;

        boxCollider = generador.GetComponent<BoxCollider2D>();
        Time.timeScale = 1;

        generadorEjemploRenderer.enabled = false;
        generadorEjemploCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Canvas_N2_A1 can = canva.GetComponent<Canvas_N2_A1>();
        CanvasFinal_N2_A1 canFin = canvaFin.GetComponent<CanvasFinal_N2_A1>();

        //Actualiza posición del cursor personalizado
        if (cursor)
        {
            MoveCursorToMouse();

            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0;
            //cursorImage.transform.position = mouseWorld;

            //Detecta clic inicial
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D hit = Physics2D.OverlapPoint(mouseWorld);
                if (hit == generadorEjemploCollider)
                {
                    isDragging = true;
                    offset = generador.transform.position - mouseWorld;
                }
            }



            //Condiconales para la activacion de los textos

            if (fase == 6)
            {
                //Vuelta al canvas

                Time.timeScale = 0; //Devuelvo el tiempo a 0
                can.canvas.enabled = true; //Activo el canvas
                can.Ejemplo.gameObject.SetActive(true);
                can.Actividad.gameObject.SetActive(true);

                generadorEjemploCollider.enabled = false; //Deshabilito el colider y el renderer del generador de ejemplo
                generadorEjemploRenderer.enabled = false;
                fase = 0; //Vuelvo a poner la fase en 0
                cursor = false; //Desactivo la imagen de la mano (para que no lo siga)
                Cursor.visible = true; //Activo el cursor para que se vea
            }

            //Condición de fin al terminar la actividad principal
            if (faseAct == 14)
            {
                Time.timeScale = 0; //Devuelvo el tiempo a 0
                canFin.canvasFinal.enabled = true; //Activo el canvas final

                generadorEjemploCollider.enabled = false; //Desabilito el colider y el renderer del generador de ejemplo
                generadorEjemploRenderer.enabled = false;
                fase = 0; //Vuelvo a poner la fase en 0
                cursor = false; //Desactivo cursor
                Cursor.visible = true; //Activo el cursor para que se vea

                can.empezado = true;
            }


        }
    }

    //Corrutina del ejemplo
    public IEnumerator Act2Ejemplo()
    {
        Detector_Colision_N2_A1 gen_ejemplo = generador.GetComponent<Detector_Colision_N2_A1>();
        Canvas_N2_A1 can = canva.GetComponent<Canvas_N2_A1>();

        while (true)
        {
            foreach (var sprite in sprite_ejemplo)
            {
                gen_ejemplo.parada = false;
                generadorEjemploRenderer.sprite = sprite;
                generador.transform.position = originalPositionEjemplo;

                fase++;
                yield return new WaitForSeconds(10f);
            }
        }
        can.corru = null;
        yield break;
    }

    //Corrutina de la actividad
    public IEnumerator Act2()
    {
        Detector_Colision_N2_A1 gen_ejemplo = generador.GetComponent<Detector_Colision_N2_A1>();
        Canvas_N2_A1 can = canva.GetComponent<Canvas_N2_A1>();

        while (true)
        {
            foreach (var sprite in sprite_actividad)
            {
                gen_ejemplo.parada = false;
                generadorEjemploRenderer.sprite = sprite;
                generador.transform.position = originalPositionEjemplo;

                faseAct++;
                yield return new WaitForSeconds(7f);
            }

        }
        can.corru = null;
        yield break;
    }

    //Esto es lo que permite que la imagen del cursor siga al cursor al ser un canvas
    private void MoveCursorToMouse()
    {
        Canvas cursorCanvas = cursorRect.GetComponentInParent<Canvas>();
        if (cursorCanvas == null)
        {
            // fallback: usar ScreenPoint directamente
            cursorRect.position = Input.mousePosition;
            return;
        }

        if (cursorCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            cursorRect.position = Input.mousePosition;
            return;
        }
        else if (cursorCanvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            // transforma punto de pantalla a world point dentro del rect del canvas
            RectTransform canvasRect = cursorCanvas.GetComponent<RectTransform>();
            Vector3 worldPoint;
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(canvasRect, Input.mousePosition, cursorCanvas.worldCamera, out worldPoint))
            {
                cursorRect.position = worldPoint;
                return;
            }
        }
        else // WorldSpace
        {
            Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            world.z = cursorRect.position.z; // mantener z del rectTransform
            cursorRect.position = world;
            return;
        }
    }
}

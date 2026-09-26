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

    [Header("Escalas Actividad")]
    public List<Vector3> escalasActividad = new List<Vector3>
{
    new Vector3(1.69f, 1.69f, 1.69f), // Zapatos
    new Vector3(1.47f, 1.47f, 1.47f), // socks
    new Vector3(1.69f, 1.69f, 1.69f), // zapatillas2
    new Vector3(3.45f, 3.45f, 3.45f), // sportSuit
    new Vector3(1.15f, 1.15f, 1.15f), // corbata2
    new Vector3(1.07f, 1.07f, 1.07f), // tenisBall
    new Vector3(3.54f, 3.54f, 3.54f), // tenisStik
    new Vector3(0.91f, 0.91f, 0.91f), // lazo2
    new Vector3(2.12f, 2.12f, 2.12f), // BasketBall
    new Vector3(2.53f, 2.53f, 2.53f), // tShirt
    new Vector3(1.38f, 1.38f, 1.38f), // hat
    new Vector3(1.17f, 1.17f, 1.17f), // bantk
    new Vector3(1.81f, 1.81f, 1.81f)  // planta
};

    [Header("Escalas Ejemplo")]
    public List<Vector3> escalasEjemplo = new List<Vector3>
{
    new Vector3(2.08f, 2.08f, 2.08f), // gorra2
    new Vector3(1.57f, 1.57f, 1.57f), // shose
    new Vector3(1.14f, 1.14f, 1.14f), // babochka
    new Vector3(2.47f, 3.62f, 3.62f), // dress
    new Vector3(2.13f, 1.645f, 1.645f) // grasHat
};

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

            if (fase == 6) //Ejemplo
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
    //Corrutina del ejemplo
    public IEnumerator Act2Ejemplo()
    {
        Detector_Colision_N2_A1 gen_ejemplo = generador.GetComponent<Detector_Colision_N2_A1>();
        Canvas_N2_A1 can = canva.GetComponent<Canvas_N2_A1>();

        while (true)
        {
            for (int i = 0; i < sprite_ejemplo.Count; i++)
            {
                // gen_ejemplo.parada = false;
                generadorEjemploRenderer.sprite = sprite_ejemplo[i];
                generador.transform.position = originalPositionEjemplo;

                // Cambio de escala según el sprite
                generador.transform.localScale = escalasEjemplo[i];

                fase++;
                yield return new WaitForSeconds(10f);
            }
        }

        can.corru = null;
        yield break;
    }

    //Corrutina de la actividad
    //Corrutina de la actividad
    public IEnumerator Act2()
    {
        Detector_Colision_N2_A1 gen_ejemplo = generador.GetComponent<Detector_Colision_N2_A1>();
        Canvas_N2_A1 can = canva.GetComponent<Canvas_N2_A1>();

        while (true)
        {
            for (int i = 0; i < sprite_actividad.Count; i++)
            {
                // gen_ejemplo.parada = false;
                generadorEjemploRenderer.sprite = sprite_actividad[i];
                generador.transform.position = originalPositionEjemplo;

                // Cambio de escala según el sprite
                generador.transform.localScale = escalasActividad[i];

                faseAct++;
                yield return new WaitForSeconds(7f);
            }
        }

        can.corru = null;
        yield break;
    }
}

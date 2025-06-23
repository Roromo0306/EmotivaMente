using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N1_Actividad1 : MonoBehaviour
{
   
    public GameObject cursorImage;

    public GameObject generador;
    public List<Sprite> imagenes;

    private SpriteRenderer generadorRenderer;
    private Collider2D generadorCollider;
    private Vector3 originalPosition;

    private bool isDragging = false;
    private Vector3 offset;

    private BoxCollider2D boxCollider;

    void Awake()
    {
        // Oculta cursor del sistema
        Cursor.visible = false;

        // Obtiene componentes
        generadorRenderer = generador.GetComponent<SpriteRenderer>();
        generadorCollider = generador.GetComponent<Collider2D>();

        // Guarda posición original del generador
        originalPosition = generador.transform.position;
    }

    void Start()
    {
        // Inicia el ciclo de sprites
        StartCoroutine(Act1());
        boxCollider = generador.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        DetectorColision GenS = generador.GetComponent<DetectorColision>();

        //Actualiza posición del cursor personalizado
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;
        cursorImage.transform.position = mouseWorld;

        //Detecta clic inicial
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);
            if (hit == generadorCollider)
            {
                isDragging = true;
                offset = generador.transform.position - mouseWorld;
            }
        }

        //Con este if lo que controlo es que si se detecta una colision entre la
        //maleta y el sprite, el jugador ya no puede coger el objeto hasta que cambie
        if (GenS.parada)
        {

        }
        else
        {
           
            if (isDragging) //Arrastrar el sprite
            {
                generador.transform.position = mouseWorld + offset;
                boxCollider.enabled = false;
            }

            
            if (Input.GetMouseButtonUp(0) && isDragging) //Suelto el sprite
            {
                boxCollider.enabled = true;
                isDragging = false;
            }
        }

        //Condición de victoria
        if(GenS.puntospos == 7 && GenS.puntosneg == 0)
        {
            //Ha acertado al 100%
        }
        else
        {
            if(GenS.puntospos <=7 && GenS.puntosneg <= 2)
            {
                //Esta bien pero con algunos fallos
            }
            else
            {
                if(GenS.puntosneg == 3)
                {
                    //esta mal
                }
            }
        }
 
    }

    //Corrutina que recorre la lista de sprites cada 7 segundos
    private IEnumerator Act1()
    {
        DetectorColision GenS = generador.GetComponent<DetectorColision>();
        while (true)
        {
            foreach (var sprite in imagenes)
            {
                GenS.parada = false;
                generadorRenderer.sprite = sprite;
                generador.transform.position = originalPosition;


                yield return new WaitForSeconds(7f);
                
                
            }
        }
    }
}



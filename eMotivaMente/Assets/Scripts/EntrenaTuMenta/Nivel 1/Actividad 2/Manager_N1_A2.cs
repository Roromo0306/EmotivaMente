using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Microsoft.Unity.VisualStudio.Editor;

public class Manager_N1_A2 : MonoBehaviour
{
    public Canvas canva, canva2;

    public List<Sprite> sprite_ejemplo, sprite_actividad;
    public TextMeshProUGUI texto1, texto2, texto3;
    public GameObject generador_ejemplo;

    public GameObject cursorImage;

    private SpriteRenderer generadorEjemploRenderer;
    private Collider2D generadorEjemploCollider;
    private Vector3 originalPositionEjemplo;

    private bool isDragging = false;
    private Vector3 offset;

    private BoxCollider2D boxCollider;

    public int fase = 0;
    public bool Fase = false;

    void Start()
    {
        // Oculta cursor del sistema
        Cursor.visible = false;

        // Obtiene componentes
        generadorEjemploRenderer = generador_ejemplo.GetComponent<SpriteRenderer>();
        generadorEjemploCollider = generador_ejemplo.GetComponent<Collider2D>();

        // Guarda posición original del generador
        originalPositionEjemplo = generador_ejemplo.transform.position;

        // Inicia el ciclo de sprites
       // StartCoroutine(Act2Ejemplo());
        boxCollider = generador_ejemplo.GetComponent<BoxCollider2D>();
        Time.timeScale = 1;

        canva2.enabled = true;
        texto2.gameObject.SetActive(false);
        texto3.gameObject.SetActive(false);
    }

   
    void Update()
    {
        DetectorColision GenS = generador_ejemplo.GetComponent<DetectorColision>();

        //Actualiza posición del cursor personalizado
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
        /*if (GenS.parada)
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
        }*/


        if(fase == 1)
        {
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(true);
            texto3.gameObject.SetActive(false);
        }
        if (fase == 2)
        {
            texto1.gameObject.SetActive(false);
            texto2.gameObject.SetActive(false);
            texto3.gameObject.SetActive(true);
        }
    }

    /*private IEnumerator Act2Ejemplo()
    {
        //DetectorColision GenS = generador_ejemplo.GetComponent<DetectorColision>();
        while (true)
        {
            foreach (var sprite in sprite_ejemplo)
            {
                GenS.parada = false;
                generadorEjemploRenderer.sprite = sprite;
                generador_ejemplo.transform.position = originalPositionEjemplo;

                fase++;
                yield return new WaitForSeconds(10f);


            }
        }
    }*/
}

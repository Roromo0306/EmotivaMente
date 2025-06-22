using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N1_Actividad1 : MonoBehaviour
{
    [Header("Cursor personalizado")]
    public GameObject cursorImage;

    [Header("Generador de sprites")]
    public GameObject generador;
    public List<Sprite> imagenes;

    private SpriteRenderer generadorRenderer;
    private Collider2D generadorCollider;
    private Vector3 originalPosition;

    [Header("Arrastre")]
    private bool isDragging = false;
    private Vector3 offset;

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
    }

    void Update()
    {
        // Actualiza posición del cursor personalizado
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;
        cursorImage.transform.position = mouseWorld;

        // Detecta clic inicial
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);
            if (hit == generadorCollider)
            {
                isDragging = true;
                offset = generador.transform.position - mouseWorld;
            }
        }

        // Arrastre
        if (isDragging)
        {
            generador.transform.position = mouseWorld + offset;
        }

        // Suelta
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            // Si quieres que vuelva a la posición original al soltar, descomenta:
            // generador.transform.position = originalPosition;
        }
    }

    private IEnumerator Act1()
    {
        while (true)
        {
            foreach (var sprite in imagenes)
            {
                generadorRenderer.sprite = sprite;
                generador.transform.position = originalPosition;
                yield return new WaitForSeconds(7f);
            }
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class N1_Actividad1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Imagen que se usará como cursor
    public RectTransform cursorImage;

    //GameObject que generan y guardan las imágenes
    public GameObject generador;
    public List<Sprite> imagenes;
    private Image generadorImage;

    //Variables para que funcione el arrastre
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    void Start()
    {
        Cursor.visible = false; // Oculta el cursor del sistema

        // Obtiene el componente Image de generador
        generadorImage = generador.GetComponent<Image>();

        //Configuración inicila para el arratre
        rectTransform = generador.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = generador.GetComponent<CanvasGroup>() ?? generador.AddComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;


        StartCoroutine(Act1());
    }

    void Update()
    {
        // Hace que la imagen siga al cursor
        Vector2 pos = Input.mousePosition;
        cursorImage.position = pos;
    }

    private IEnumerator Act1()
    {
        // Bucle infinito que recorre la lista de sprites
        while (true)
        {
            foreach (Sprite sprite in imagenes)
            {
                generadorImage.sprite = sprite;
                rectTransform.anchoredPosition = originalPosition; //Restablece la posición

                yield return new WaitForSeconds(7f);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Hace ligeramente transparente
        canvasGroup.blocksRaycasts = false; // Permite que eventos pasen a objetos detrás
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convierte la posición del ratón a coordenadas del Canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Restaura opacidad
        canvasGroup.blocksRaycasts = true; // Habilita nuevamente los raycasts
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class N1_Actividad1 : MonoBehaviour
{
    // Imagen que se usará como cursor
    public RectTransform cursorImage;

    //GameObject que generan y guardan las imágenes
    public GameObject generador;
    public List<Sprite> imagenes;
    private Image generadorImage;


    void Start()
    {
        Cursor.visible = false; // Oculta el cursor del sistema

        // Obtiene el componente Image de generador
        generadorImage = generador.GetComponent<Image>();
       
        StartCoroutine(Act1());

        //Esto asegura que el generador tenga un CanvasGroup (para que funcione lo de coger el objeto)
        if (generador.GetComponent<CanvasGroup>() == null)
        {
            generador.AddComponent<CanvasGroup>();
        }

        //Esto añade un manegador de eventos para coger y soltar
        if(generador.GetComponent<N1_DragAndDrop>() == null)
        {
            generador.AddComponent<N1_DragAndDrop>();
        }
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

                yield return new WaitForSeconds(7f);
            }
        }
    }
}


public class N1_DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Al iniciar el drag, permite que el objeto ignore los raycasts para no bloquear otros
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Mientras arrastramos, movemos el transform a la posición del cursor
        RectTransform rt = GetComponent<RectTransform>();
        Vector2 globalMousePos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rt.parent as RectTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.localPosition = globalMousePos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Al soltar, vuelve a bloquear los raycasts
        canvasGroup.blocksRaycasts = true;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//IPointerDownHandLer se usa con la funcion OnPointerDown para los eventos del raton tras pulsarlo
//IBeginDragHandler y IEndDragHandler se usan con las funciones OnBeginDrag y OnEndDrag respectivamente para los eventos de arrastras con el raton
//IDragHandler se usa con la funcion OnDrag que se llamara cada frame mientras cogamos el objeto
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [Tooltip("ID maleta")]
    public int itemID = 0;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        originalParent = transform.parent;
    }

    //Este evento se llama cuando se empieza a coger algo con el raton
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; //Se hace un poco transparente
        canvasGroup.blocksRaycasts = false;

        // ADDED: al empezar a arrastrar, guardamos el padre actual y lo movemos al canvas para poder arrastrarlo libremente
        originalParent = transform.parent;
        if (canvas != null)
        {
            transform.SetParent(canvas.transform);
            transform.SetAsLastSibling();
        }
    }

    //Se llama cada frame que cogamos el objeto y el raton se este moviendo. En esta funcion haremos que el objeto se mueva
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //Lo de delta contiene lo que se ha movido el mouse en el anterior frame. Con esto estaremos moviendo el objeto con el mouse. Lo del canvas es para que se adapte a la escala del canvas

    }

    //Este evento se llama cuando se deja de coger algo con el raton
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }


    //Esta funcion se llamara cuando el raton este presionado encima del objeto que tiene el script
    public void OnPointerDown(PointerEventData eventData)
    {

    }
}

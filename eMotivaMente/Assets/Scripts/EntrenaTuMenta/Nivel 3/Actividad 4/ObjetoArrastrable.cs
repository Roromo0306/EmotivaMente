using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjetoArrastrable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isComidaOBebida;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private GameControllerN3_4 controller;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        controller = FindObjectOfType<GameControllerN3_4>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // Al soltar, validar si cayó en el camión
        if (controller.CayoEnElCamion(rectTransform))
        {
            controller.RegistroDeArrastre(isComidaOBebida);
            Destroy(gameObject);
        }
    }
}

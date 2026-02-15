using UnityEngine;
using UnityEngine.EventSystems;

public class Prenda : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool esArriba;
    public bool esRoja;
    public bool esAzul;

    private CanvasGroup canvasGroup;
    private Vector3 posicionInicial;
    private Transform padreInicial;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posicionInicial = transform.position;
        padreInicial = transform.parent;

        canvasGroup.blocksRaycasts = false;

        Debug.Log($"[DRAG INICIO] {name}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        transform.position = posicionInicial;
        transform.SetParent(padreInicial);

        Debug.Log($"[DRAG FIN] {name}");
    }
}
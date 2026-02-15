using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Prenda : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool esArriba;
    public bool esRoja;
    public bool esAzul;

    public Sprite sprite;

    private Transform padreOriginal;
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        padreOriginal = transform.parent;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(padreOriginal);
    }
}

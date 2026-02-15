using UnityEngine;
using UnityEngine.EventSystems;

public class DropManiqui : MonoBehaviour, IDropHandler
{
    public bool esArriba;
    public Manager_N4_A5 manager;

    public void OnDrop(PointerEventData eventData)
    {
        Prenda prenda = eventData.pointerDrag.GetComponent<Prenda>();
        if (prenda != null)
        {
            manager.ColocarPrenda(prenda, esArriba);
        }
    }
}
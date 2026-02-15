using UnityEngine;
using UnityEngine.EventSystems;

public class DropManiqui : MonoBehaviour, IDropHandler
{
    public bool esZonaArriba;
    public Manager_N4_A5 manager;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("[DROP DETECTADO]");

        if (eventData.pointerDrag == null)
        {
            Debug.Log("[DROP] pointerDrag es null");
            return;
        }

        Prenda prenda = eventData.pointerDrag.GetComponent<Prenda>();

        if (prenda == null)
        {
            Debug.Log("[DROP] No es una prenda");
            return;
        }

        Debug.Log($"[DROP OK] {prenda.name}");
        manager.ColocarPrenda(prenda, esZonaArriba);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//IDropHandler se usa con la funcion OnDropt para dejar los objetos
public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Tooltip("ID del hueco")]
    public int slotID = 0;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) //eventData.pointerDrag guarda el objeto que se estaba cogiendo
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; //Esto hace que el objeto que se esta llevando se encaje en el que se deja

            eventData.pointerDrag.transform.SetParent(transform); //Hace que el objeto que se coja sea hijo del objeto en el que se deja
        }
    }
}

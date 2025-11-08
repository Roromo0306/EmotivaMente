using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler
{
    
    public void OnDrag(PointerEventData eventData)
    {
       // Esto mueve el objeto según el movimiento del ratón
       transform.position += (Vector3)eventData.delta;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag_N2_A1 : MonoBehaviour, IDragHandler
{
    
    public void OnDrag(PointerEventData eventData)
    {
        Detector_Colision_N2_A1 dt = GetComponent<Detector_Colision_N2_A1>();

        if (!dt.parada)
        {
            // Esto mueve el objeto según el movimiento del ratón
            transform.position += (Vector3)eventData.delta;
        }

    }
}

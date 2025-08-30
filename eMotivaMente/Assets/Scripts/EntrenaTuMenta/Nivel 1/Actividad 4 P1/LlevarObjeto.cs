using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LlevarObjeto : MonoBehaviour, IDragHandler
{
    public bool activado = false;
    public void OnDrag(PointerEventData eventData)
    {
        if(activado)
        {
            // Esto mueve el objeto seg�n el movimiento del rat�n
            transform.position += (Vector3)eventData.delta;
        }
    }
}

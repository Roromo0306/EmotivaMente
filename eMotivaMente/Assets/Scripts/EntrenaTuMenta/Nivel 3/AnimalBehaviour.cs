using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalBehaviour : MonoBehaviour, IPointerClickHandler
{
    public AnimalData data;
    public GameController_N3 controller;

    private bool selected = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (selected) return;

        selected = true;
        controller.RegisterSelection(data);

        // efecto visual simple
        GetComponent<Image>().color = Color.yellow;
    }
}

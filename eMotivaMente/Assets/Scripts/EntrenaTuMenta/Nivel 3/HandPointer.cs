using UnityEngine;

public class HandPointer : MonoBehaviour
{
    public RectTransform hand;
    public Canvas canvas;

    void Update()
    {
        Vector2 pos;

        if (Input.touchCount > 0)
            pos = Input.touches[0].position;
        else
            pos = Input.mousePosition;

        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            pos,
            canvas.worldCamera,
            out localPos
        );

        hand.anchoredPosition = localPos;
    }
}

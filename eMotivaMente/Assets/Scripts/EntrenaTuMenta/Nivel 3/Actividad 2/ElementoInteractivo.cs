using UnityEngine;
using UnityEngine.UI;

public class ElementoInteractivo : MonoBehaviour
{
    public bool isCactus;
    public bool isInverted;

    private GameControllerN3_2 controller;

    void Start()
    {
        controller = FindObjectOfType<GameControllerN3_2>();
    }

    public void OnClick()
    {
        bool isCorrect = isCactus && !isInverted;
        controller.RegisterClick(isCorrect);

        Destroy(gameObject);
    }
}

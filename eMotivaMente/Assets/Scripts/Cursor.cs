using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGlob : MonoBehaviour
{
    public static CursorGlob Instance;

    [Header("Cursor UI")]
    public GameObject cursorImage;

    private void Awake()
    {
        // Evita que se creen varios cursores
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Mantiene el cursor entre escenas
        DontDestroyOnLoad(gameObject);

        // Ocultamos el cursor original
        Cursor.visible = false;
    }

    private void Start()
    {
        cursorImage.SetActive(true);
    }

    private void Update()
    {
        // Movemos el cursor UI directamente a la posición del ratón
        cursorImage.GetComponent<RectTransform>().position = Input.mousePosition;
    }
}

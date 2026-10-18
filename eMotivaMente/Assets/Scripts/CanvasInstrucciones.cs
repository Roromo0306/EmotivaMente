using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInstrucciones : MonoBehaviour
{
    public GameObject canvasInstruccines;

    public void QuitarInstrucciones()
    {
        canvasInstruccines.SetActive(!canvasInstruccines.activeSelf);
    }
}

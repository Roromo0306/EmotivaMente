using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasFinal_N1_A4_1 : MonoBehaviour
{
    public Button siguienteParte;
    void Start()
    {
        siguienteParte.onClick.AddListener(siguiente);
    }

    private void siguiente()
    {
        SceneManager.LoadScene("N1_Actividad 4.2");
    }
   
    void Update()
    {
        
    }
}

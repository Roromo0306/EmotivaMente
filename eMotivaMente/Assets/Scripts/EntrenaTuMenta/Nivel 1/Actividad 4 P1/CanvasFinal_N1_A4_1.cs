using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasFinal_N1_A4_1 : MonoBehaviour
{
    public Button siguienteParte;
    public GameObject cronometro;
    void Start()
    {
        siguienteParte.onClick.AddListener(siguiente);
    }

    private void siguiente()
    {
        CronómetroN1_A4 crono = cronometro.GetComponent<CronómetroN1_A4>();
        DatosEmotivamente.Instance.tiempoN1_A4_1 = crono.tiempo;
        SceneManager.LoadScene("N1_Actividad 4.2");
    }
}

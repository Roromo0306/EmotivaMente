using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasFinal_N1_A4_2 : MonoBehaviour
{
    public Button volverMenu;
    public GameObject cronometro;
    void Start()
    {
        volverMenu.onClick.AddListener(Volver);
    }

    private void Volver()
    {
        Cron�metroN1_A4 crono = cronometro.GetComponent<Cron�metroN1_A4>();

        DatosEmotivamente.Instance.tiempoN1_A4_2 = crono.tiempo;
        Menu_Nivel1_Entrena.n4 = true;
        SceneManager.LoadScene("Men� del nivel 1");
    }
}

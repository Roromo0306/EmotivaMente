using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirPrograma : MonoBehaviour
{
    public void SalirSinDatos()
    {
        Application.Quit();
    }

    public void SalirConDatos()
    {
        if (DatosEmotivamente.Instance != null)
        {
            DatosEmotivamente.Instance.EnviarDatos();
            Application.Quit();
        }
        else
        {
            Debug.LogWarning("DatosEmotivamente.Instance es null — no se enviaron los datos.");
            Application.Quit();
        }
    }
}

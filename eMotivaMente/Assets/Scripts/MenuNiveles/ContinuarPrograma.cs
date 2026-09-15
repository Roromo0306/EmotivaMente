using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuarPrograma : MonoBehaviour
{
    public GameObject Intrucciones;
    public GameObject MenuNiveles;
     
    public void continuar()
    {
        Intrucciones.gameObject.SetActive(false);
        MenuNiveles.gameObject.SetActive(true);
    }

    public void continuarNivel1()
    {
        SceneManager.LoadScene("Menú del nivel 1");
    }
}

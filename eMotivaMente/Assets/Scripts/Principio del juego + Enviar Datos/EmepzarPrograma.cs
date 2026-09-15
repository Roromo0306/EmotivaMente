using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmepzarPrograma : MonoBehaviour
{
    public GameObject PrimerMenu;
    public GameObject MenuRegistro;
    public GameObject MenuIntrucciones;

    public void Start()
    {
        //Desactivamos los dos menus
        MenuRegistro.gameObject.SetActive(false);
        MenuIntrucciones.gameObject.SetActive(false); 
    }

    public void EmpezarPrimero()
    {
        PrimerMenu.gameObject.SetActive(false);
        MenuIntrucciones.gameObject.SetActive(true);
    }

    public void SalirPrimero()
    {
        Application.Quit();
    }

    public void Continuar()
    {
        MenuIntrucciones.gameObject.SetActive(false);
        MenuRegistro.gameObject.SetActive(true);

    }
}

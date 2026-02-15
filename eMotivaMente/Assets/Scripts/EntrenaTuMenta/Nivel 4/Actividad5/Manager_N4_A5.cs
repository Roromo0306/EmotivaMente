using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N4_A5 : MonoBehaviour
{
    public enum Modo { Nada, Ejemplo, Actividad }
    private Modo modo = Modo.Nada;

    [Header("Prendas")]
    public List<Prenda> prendasArriba;
    public List<Prenda> prendasAbajo;

    [Header("UI")]
    public Image imgArriba;
    public Image imgAbajo;

    [Header("Canvas")]
    public Canvas_N4_A5 canvas;

    private int errores = 0;
    private bool arribaCorrecto = false;
    private bool abajoCorrecto = false;

    void Start()
    {
        OcultarPrendas();
    }

    public void IniciarEjemplo()
    {
        Preparar(Modo.Ejemplo);
    }

    public void IniciarActividad()
    {
        Preparar(Modo.Actividad);
    }

    public void ReiniciarActividad()
    {
        errores = 0;
        Preparar(Modo.Actividad);
    }

    void Preparar(Modo m)
    {
        modo = m;
        errores = 0;
        arribaCorrecto = false;
        abajoCorrecto = false;

        MostrarPrendas();
        StartCoroutine(CambiarPrendas());
    }

    IEnumerator CambiarPrendas()
    {
        while (!(arribaCorrecto && abajoCorrecto))
        {
            imgArriba.sprite = prendasArriba[Random.Range(0, prendasArriba.Count)].sprite;
            imgAbajo.sprite = prendasAbajo[Random.Range(0, prendasAbajo.Count)].sprite;

            yield return new WaitForSeconds(3f);
        }

        Evaluar();
        OcultarPrendas();
    }

    public void ColocarPrenda(Prenda prenda, bool esArriba)
    {
        if (modo == Modo.Ejemplo)
        {
            if (prenda.esArriba == esArriba)
            {
                if (esArriba) arribaCorrecto = true;
                else abajoCorrecto = true;
            }
            else
                errores++;
        }
        else
        {
            if (prenda.esArriba == esArriba &&
                ((esArriba && prenda.esRoja) || (!esArriba && prenda.esAzul)))
            {
                if (esArriba) arribaCorrecto = true;
                else abajoCorrecto = true;
            }
            else
                errores++;
        }
    }

    void Evaluar()
    {
        if (errores == 0)
            canvas.MostrarResultado(true, false);
        else if (errores <= 2)
            canvas.MostrarResultado(true, true);
        else
            canvas.MostrarResultado(false, true);
    }

    void MostrarPrendas()
    {
        imgArriba.gameObject.SetActive(true);
        imgAbajo.gameObject.SetActive(true);
    }

    void OcultarPrendas()
    {
        imgArriba.gameObject.SetActive(false);
        imgAbajo.gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerN4_A1 : MonoBehaviour
{
    public enum Modo { Nada, Ejemplo, Actividad }
    private Modo modo = Modo.Nada;

    [Header("Sprites")]
    public List<Sprite> carasPositivas;
    public List<Sprite> carasNegativas;

    private List<Sprite> secuencia = new List<Sprite>();

    [Header("UI Juego")]
    public Image imgCara;
    public Button btnSaludar;

    [Header("Canvas")]
    public CanvasN4_A1 canvas;

    private int indice = 0;
    private bool pulsado = false;
    private int errores = 0;

    void Start()
    {
        btnSaludar.onClick.AddListener(Saludar);
        imgCara.gameObject.SetActive(false);
        btnSaludar.gameObject.SetActive(false);
    }

    // ===================== INICIOS =====================

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
        indice = 0;
        errores = 0;
        CrearSecuencia();

        imgCara.gameObject.SetActive(true);
        btnSaludar.gameObject.SetActive(true);

        StopAllCoroutines();

        if (modo == Modo.Ejemplo)
            StartCoroutine(Ejemplo());
        else
            StartCoroutine(Actividad());
    }

    // ===================== JUEGO =====================

    void CrearSecuencia()
    {
        secuencia.Clear();

        for (int i = 0; i < 5; i++)
        {
            secuencia.Add(carasPositivas[i]);
            secuencia.Add(carasNegativas[i]);
        }

        for (int i = 0; i < secuencia.Count; i++)
        {
            int rnd = Random.Range(i, secuencia.Count);
            (secuencia[i], secuencia[rnd]) = (secuencia[rnd], secuencia[i]);
        }
    }

    void Saludar()
    {
        pulsado = true;

        if (modo == Modo.Actividad)
        {
            if (!carasPositivas.Contains(imgCara.sprite))
                errores++;
        }
    }

    IEnumerator Ejemplo()
    {
        while (indice < secuencia.Count)
        {
            imgCara.sprite = secuencia[indice];
            yield return new WaitForSeconds(5f);
            indice++;
        }

        Finalizar();
    }

    IEnumerator Actividad()
    {
        while (indice < secuencia.Count)
        {
            imgCara.sprite = secuencia[indice];
            pulsado = false;

            float t = 0;
            while (t < 5f && !pulsado)
            {
                t += Time.deltaTime;
                yield return null;
            }

            if (!pulsado && carasPositivas.Contains(imgCara.sprite))
                errores++;

            indice++;
        }

        Evaluar();
        Finalizar();
    }

    // ===================== FINAL =====================

    void Evaluar()
    {
        if (errores == 0)
            canvas.MostrarMenuFinal(true, false);
        else if (errores <= 2)
            canvas.MostrarMenuFinal(true, true);
        else
            canvas.MostrarMenuFinal(false, true);
    }

    void Finalizar()
    {
        imgCara.gameObject.SetActive(false);
        btnSaludar.gameObject.SetActive(false);
        modo = Modo.Nada;
    }
}

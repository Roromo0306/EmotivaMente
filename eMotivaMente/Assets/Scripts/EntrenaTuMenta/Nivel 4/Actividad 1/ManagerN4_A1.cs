using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerN4_A1 : MonoBehaviour
{
    [HideInInspector] public int modo = 0; // 0 nada, 1 ejemplo, 2 actividad
    private bool empezar = false;
    private bool presionado = false;

    [Header("Caras")]
    public List<Sprite> carasPositivas;
    public List<Sprite> carasNegativas;
    private List<Sprite> secuencia = new List<Sprite>();

    public Image caraActual;
    public Canvas canvaInicio;

    [Header("Botón Saludar")]
    public Button Saludar;

    public int cont = 0;
    public int puntuacion = 0;
    public int errores = 0;

    void Start()
    {
        Saludar.onClick.AddListener(SaludarF);
        caraActual.gameObject.SetActive(false);
    }

    void Update()
    {
        if (modo == 1 && !empezar)
        {
            empezar = true;
            CrearSecuencia();
            caraActual.gameObject.SetActive(true);
            StartCoroutine(EjemploF());
        }

        if (modo == 2 && !empezar)
        {
            empezar = true;
            CrearSecuencia();
            caraActual.gameObject.SetActive(true);
            StartCoroutine(ActividadF());
        }
    }

    void CrearSecuencia()
    {
        secuencia.Clear();

        for (int i = 0; i < 5; i++)
        {
            secuencia.Add(carasPositivas[i]);
            secuencia.Add(carasNegativas[i]);
        }

        // Mezclar
        for (int i = 0; i < secuencia.Count; i++)
        {
            Sprite temp = secuencia[i];
            int rnd = Random.Range(i, secuencia.Count);
            secuencia[i] = secuencia[rnd];
            secuencia[rnd] = temp;
        }
    }

    private void SaludarF()
    {
        presionado = true;

        if (modo == 2)
        {
            if (carasPositivas.Contains(caraActual.sprite))
                puntuacion++;
            else
                errores++;
        }
    }

    IEnumerator EjemploF()
    {
        while (cont < secuencia.Count)
        {
            caraActual.sprite = secuencia[cont];
            presionado = false;

            yield return new WaitForSeconds(5f);
            cont++;
        }

        Resetear();
        yield break;
    }

    IEnumerator ActividadF()
    {
        CanvasN4_A1 canva = canvaInicio.GetComponent<CanvasN4_A1>();

        while (cont < secuencia.Count)
        {
            caraActual.sprite = secuencia[cont];
            presionado = false;

            float tiempo = 0f;
            while (tiempo < 5f && !presionado)
            {
                tiempo += Time.deltaTime;
                yield return null;
            }

            if (!presionado && carasPositivas.Contains(caraActual.sprite))
                errores++;

            cont++;
        }

        caraActual.gameObject.SetActive(false);
        canvaInicio.enabled = true;

        // Valoración
        if (errores == 0)
        {
            canva.Menu.gameObject.SetActive(true);
        }
        else if (errores <= 2)
        {
            canva.Menu.gameObject.SetActive(true);
            canva.Reintentar.gameObject.SetActive(true);
        }
        else
        {
            canva.Reintentar.gameObject.SetActive(true);
        }

        Resetear();
        yield break;
    }

    void Resetear()
    {
        cont = 0;
        modo = 0;
        empezar = false;
    }
}

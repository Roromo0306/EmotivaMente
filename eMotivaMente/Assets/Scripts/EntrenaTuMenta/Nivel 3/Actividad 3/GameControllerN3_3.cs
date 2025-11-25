using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameControllerN3_3 : MonoBehaviour
{
    [Header("UI")]
    public Image imagenUI;
    public Text contadorText;
    public Button botonVerde;

    [Header("Sprites")]
    public List<Sprite> imagenesDesierto;
    public List<Sprite> imagenesNoDesierto;

    private float tiempoPorImagen = 7f;
    private float timer;

    private bool esperandoInput = false;
    private bool imagenEsDelDesierto = false;
    private int errores = 0;

    private List<Elemento> secuencia = new List<Elemento>();
    private int indice = 0;

    void Start()
    {
        CrearSecuencia();
        MostrarSiguienteImagen();
    }

    void Update()
    {
        if (!esperandoInput) return;

        timer -= Time.deltaTime;
        contadorText.text = timer.ToString("0");

        if (timer <= 0)
        {
            EvaluarSinInput();
        }
    }

    void CrearSecuencia()
    {
        secuencia.Clear();

        // 10 del desierto
        for (int i = 0; i < 10; i++)
            secuencia.Add(new Elemento(imagenesDesierto[i % imagenesDesierto.Count], true));

        // 10 no desierto
        for (int i = 0; i < 10; i++)
            secuencia.Add(new Elemento(imagenesNoDesierto[i % imagenesNoDesierto.Count], false));

        // Mezclar
        for (int i = 0; i < secuencia.Count; i++)
        {
            int rnd = Random.Range(i, secuencia.Count);
            (secuencia[i], secuencia[rnd]) = (secuencia[rnd], secuencia[i]);
        }
    }

    void MostrarSiguienteImagen()
    {
        if (indice >= secuencia.Count)
        {
            FinDelJuego();
            return;
        }

        imagenUI.sprite = secuencia[indice].sprite;
        imagenEsDelDesierto = secuencia[indice].esDelDesierto;

        timer = tiempoPorImagen;
        esperandoInput = true;

        indice++;
    }

    void EvaluarSinInput()
    {
        // Si era del desierto y NO pulsó → error
        if (imagenEsDelDesierto)
            errores++;

        esperandoInput = false;
        MostrarSiguienteImagen();
    }

    public void UsarBotonVerde()
    {
        if (!esperandoInput) return;

        // Si pulsa cuando NO debe → error
        if (!imagenEsDelDesierto)
            errores++;

        esperandoInput = false;
        MostrarSiguienteImagen();
    }

    void FinDelJuego()
    {
        if (errores == 0)
            Debug.Log("¡FELICITACIONES! No hay errores.");
        else
            Debug.Log("Inténtalo de nuevo. Hubo " + errores + " errores.");
    }
}

[System.Serializable]
public class Elemento
{
    public Sprite sprite;
    public bool esDelDesierto;

    public Elemento(Sprite s, bool desert)
    {
        sprite = s;
        esDelDesierto = desert;
    }
}

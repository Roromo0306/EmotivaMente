using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameControllerN3_4 : MonoBehaviour
{
    [Header("UI")]
    public Image currentImageUI; // opcional
    public RectTransform spawnArea;
    public CamionDropArea camion;
    public Text timerText;

    [Header("Prefab")]
    public GameObject objetoPrefab;

    [Header("Sprites")]
    public List<Sprite> comidaYbebida;
    public List<Sprite> noValidos;

    private List<ObjetoData> secuencia = new List<ObjetoData>();
    private int indice = 0;

    private float tiempoPorObjeto = 7f;
    private float timer;

    private bool objetoEnPantalla = false;

    private GameObject objetoActual;
    private ObjetoArrastrable scriptActual;

    private int errores = 0;

    void Start()
    {
        CrearSecuencia();
        MostrarSiguiente();
    }

    void Update()
    {
        if (!objetoEnPantalla) return;

        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();

        if (timer <= 0)
            TiempoTerminado();
    }

    void CrearSecuencia()
    {
        secuencia.Clear();

        // 14 válidos
        for (int i = 0; i < 14; i++)
            secuencia.Add(new ObjetoData(comidaYbebida[Random.Range(0, comidaYbebida.Count)], true));

        // 6 incorrectos
        for (int i = 0; i < 6; i++)
            secuencia.Add(new ObjetoData(noValidos[Random.Range(0, noValidos.Count)], false));

        // Mezclar
        for (int i = 0; i < secuencia.Count; i++)
        {
            int rnd = Random.Range(i, secuencia.Count);
            (secuencia[i], secuencia[rnd]) = (secuencia[rnd], secuencia[i]);
        }
    }

    void MostrarSiguiente()
    {
        if (indice >= secuencia.Count)
        {
            FinDelJuego();
            return;
        }

        objetoEnPantalla = true;
        timer = tiempoPorObjeto;

        CrearObjeto(secuencia[indice]);
        indice++;
    }

    void CrearObjeto(ObjetoData data)
    {
        objetoActual = Instantiate(objetoPrefab, spawnArea);
        objetoActual.GetComponent<Image>().sprite = data.sprite;

        scriptActual = objetoActual.GetComponent<ObjetoArrastrable>();
        scriptActual.isComidaOBebida = data.esComida;
    }

    void TiempoTerminado()
    {
        objetoEnPantalla = false;

        // si era válido y no lo arrastró → error
        if (scriptActual.isComidaOBebida)
            errores++;

        Destroy(objetoActual);

        MostrarSiguiente();
    }

    public bool CayoEnElCamion(RectTransform objeto)
    {
        return RectOverlaps(objeto, camion.areaRect);
    }

    public void RegistroDeArrastre(bool esComida)
    {
        objetoEnPantalla = false;

        if (!esComida)
            errores++;

        MostrarSiguiente();
    }

    void FinDelJuego()
    {
        if (errores == 0)
            Debug.Log("¡Felicitaciones!");
        else if (errores <= 2)
            Debug.Log("Muy bien, aunque hay algún pequeño error. ¡Adelante!");
        else
            Debug.Log("Repite la actividad. Pruébalo de nuevo.");
    }

    bool RectOverlaps(RectTransform a, RectTransform b)
    {
        Vector3[] aCorners = new Vector3[4];
        Vector3[] bCorners = new Vector3[4];

        a.GetWorldCorners(aCorners);
        b.GetWorldCorners(bCorners);

        Rect rectA = new Rect(aCorners[0], aCorners[2] - aCorners[0]);
        Rect rectB = new Rect(bCorners[0], bCorners[2] - bCorners[0]);

        return rectA.Overlaps(rectB);
    }
}

public class ObjetoData
{
    public Sprite sprite;
    public bool esComida;

    public ObjetoData(Sprite s, bool comida)
    {
        sprite = s;
        esComida = comida;
    }
}

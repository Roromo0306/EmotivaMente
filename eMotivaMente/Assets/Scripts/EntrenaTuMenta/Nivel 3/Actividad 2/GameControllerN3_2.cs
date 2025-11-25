using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameControllerN3_2 : MonoBehaviour
{
    public Transform container;
    public GameObject elementoPrefab;
    public Text timerText;

    public float totalTime = 120f;

    private int errors = 0;
    private float timer;

    public List<Sprite> cactusNormal;
    public List<Sprite> cactusInvertidos;
    public List<Sprite> objetosVerdes;

    void Start()
    {
        timer = totalTime;
        GenerateScreen();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = Mathf.Ceil(timer).ToString();

        if (timer <= 0)
            EndGame();
    }

    public void RegisterClick(bool correct)
    {
        if (!correct)
            errors++;

        // Cada objeto se destruye desde ElementoInteractivo
    }

    void GenerateScreen()
    {
        List<ElementData> allElements = new List<ElementData>();

        // 16 cactus correctos
        for (int i = 0; i < 16; i++)
            allElements.Add(new ElementData(cactusNormal[Random.Range(0, cactusNormal.Count)], true, false));

        // 8 invertidos
        for (int i = 0; i < 8; i++)
            allElements.Add(new ElementData(cactusInvertidos[Random.Range(0, cactusInvertidos.Count)], true, true));

        // 8 objetos verdes (4 normales + 4 invertidos)
        for (int i = 0; i < 4; i++)
            allElements.Add(new ElementData(objetosVerdes[Random.Range(0, objetosVerdes.Count)], false, false));

        for (int i = 0; i < 4; i++)
            allElements.Add(new ElementData(objetosVerdes[Random.Range(0, objetosVerdes.Count)], false, true));

        // Mezclar
        Shuffle(allElements);

        // Instanciar
        foreach (var element in allElements)
        {
            GameObject obj = Instantiate(elementoPrefab, container);
            obj.GetComponent<Image>().sprite = element.sprite;

            var inter = obj.GetComponent<ElementoInteractivo>();
            inter.isCactus = element.isCactus;
            inter.isInverted = element.isInverted;
        }
    }

    void Shuffle(List<ElementData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

    public void EndGame()
    {
        if (errors == 0 || errors == 1)
            Debug.Log("¡Felicidades!");
        else if (errors == 2)
            Debug.Log("Muy bien, aunque hay algún pequeño error. ¡Adelante!");
        else
            Debug.Log("Repite la actividad. ¡Pruébalo de nuevo!");
    }
}

public class ElementData
{
    public Sprite sprite;
    public bool isCactus;
    public bool isInverted;

    public ElementData(Sprite s, bool cactus, bool inverted)
    {
        sprite = s;
        isCactus = cactus;
        isInverted = inverted;
    }
}

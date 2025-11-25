using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManagerN3_5 : MonoBehaviour
{
    [Header("UI")]
    public Image imageDisplay;
    public Button greenButton;
    public TextMeshProUGUI resultText;

    [Header("Path")]
    public Image[] tiles; // 20 casillas

    [Header("Elements")]
    public ElementDataN3_5[] elements; // lista completa aleatoria (consistente con el tipo)

    private int currentTile = 0;
    private ElementDataN3_5 currentElement; // <-- tipo consistente
    private bool answered = false;

    private void Start()
    {
        ResetTiles();
        greenButton.onClick.AddListener(OnGreenButtonPressed);
        StartCoroutine(GameLoop());
    }

    void ResetTiles()
    {
        if (tiles == null) return;
        foreach (var tile in tiles)
            if (tile != null) tile.color = Color.black;

        currentTile = 0;
    }

    IEnumerator GameLoop()
    {
        if (elements == null || elements.Length == 0)
        {
            resultText.text = "No hay elementos configurados.";
            yield break;
        }

        for (int i = 0; i < elements.Length; i++)
        {
            answered = false;

            // seleccionar elemento aleatorio
            currentElement = elements[Random.Range(0, elements.Length)];
            if (imageDisplay != null) imageDisplay.sprite = currentElement.sprite;

            float timer = 7f;
            while (timer > 0f && !answered)
            {
                timer -= Time.deltaTime;
                yield return null;
            }

            // si no se contestó → la lógica depende del tipo
            if (!answered)
            {
                if (currentElement.isHelpful)
                    RegisterError();
                else
                    RegisterCorrect();
            }

            // comprobar si se llegó a la meta
            if (currentTile >= tiles.Length)
            {
                if (resultText != null) resultText.text = "¡Felicidades, llegaste a la meta!";
                yield break;
            }

            // pequeño retardo opcional entre imágenes
            yield return new WaitForSeconds(0.15f);
        }

        if (resultText != null) resultText.text = "No has llegado a la meta. ¡Inténtalo de nuevo!";
    }

    public void OnGreenButtonPressed()
    {
        if (currentElement == null) return;
        answered = true;

        if (currentElement.isHelpful)
            RegisterCorrect();
        else
            RegisterError();
    }

    void RegisterCorrect()
    {
        if (tiles == null) return;

        if (currentTile < tiles.Length && tiles[currentTile] != null)
        {
            tiles[currentTile].color = Color.green;
            currentTile++;
        }
    }

    void RegisterError()
    {
        if (tiles == null) return;

        // marca la casilla actual (si existe) en rojo temporalmente
        if (currentTile < tiles.Length && tiles[currentTile] != null)
        {
            tiles[currentTile].color = Color.red;
        }

        // retroceder sólo si hay casillas verdes ya ganadas
        if (currentTile > 0)
        {
            StartCoroutine(RestoreAndGoBack());
        }
    }

    IEnumerator RestoreAndGoBack()
    {
        // Tiempo para que el usuario vea el rojo
        yield return new WaitForSeconds(0.5f);

        // Si currentTile está dentro de bounds, limpiarla (la roja)
        if (currentTile < tiles.Length && tiles[currentTile] != null)
            tiles[currentTile].color = Color.black;

        // retroceder una correcta (si existe) y borrarla
        int previous = currentTile - 1;
        if (previous >= 0 && previous < tiles.Length && tiles[previous] != null)
        {
            tiles[previous].color = Color.black;
            currentTile = previous;
        }
        else
        {
            // si no había casilla anterior, aseguramos que currentTile no sea negativo
            currentTile = Mathf.Max(0, currentTile);
        }
    }
}

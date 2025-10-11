using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AvatarCustomizer : MonoBehaviour
{
    public List<Sprite> hairSprites = new List<Sprite>();


    [Header("Capas")]
    public Image skinLayer;
    public Image hairLayer;
    public Image eyesLayer;
    public Image noseLayer;
    public Image mouthLayer;

    [Header("Dropdowns de rasgos")]
    public TMP_Dropdown hairDropdown;
    public TMP_Dropdown eyesDropdown;
    public TMP_Dropdown noseDropdown;
    public TMP_Dropdown mouthDropdown;

    [Header("Controles de color")]
    public Slider skinColorSlider;   // Rango 0 - (skinColors.Count - 1)
    public Slider hairColorSlider;   // Rango 0 - (hairColors.Count - 1)

    [Header("Paletas de colores")]
    public List<Color> skinColors = new List<Color>()
    {
        new Color(1f, 0.8f, 0.6f),   // claro
        new Color(0.9f, 0.7f, 0.5f),
        new Color(0.8f, 0.6f, 0.4f),
        new Color(0.6f, 0.4f, 0.25f),
        new Color(0.45f, 0.3f, 0.18f)
    };

    public List<Color> hairColors = new List<Color>()
    {
        new Color(0.1f, 0.05f, 0.02f), // negro
        new Color(0.25f, 0.15f, 0.05f),// castaño oscuro
        new Color(0.4f, 0.25f, 0.1f),  // castaño claro
        new Color(0.7f, 0.55f, 0.2f),  // rubio
        new Color(0.8f, 0.5f, 0.2f),   // pelirrojo
        new Color(0.95f, 0.95f, 0.95f) // blanco / gris
    };

    private AvatarData avatar;
   
    void Start()
    {
        // Cargar datos previos
        AvatarManager.Instance.LoadAvatar();
        avatar = AvatarManager.Instance.avatarData;

        // Configurar sliders
        if (skinColorSlider != null)
        {
            skinColorSlider.minValue = 0;
            skinColorSlider.maxValue = skinColors.Count - 1;
            skinColorSlider.wholeNumbers = true;
            skinColorSlider.onValueChanged.AddListener(ChangeSkinColor);
        }

        if (hairColorSlider != null)
        {
            hairColorSlider.minValue = 0;
            hairColorSlider.maxValue = hairColors.Count - 1;
            hairColorSlider.wholeNumbers = true;
            hairColorSlider.onValueChanged.AddListener(ChangeHairColor);
        }

        ApplyAvatar();
    }

    // Cambia color de piel según el índice del slider
    public void ChangeSkinColor(float index)
    {
        int i = Mathf.RoundToInt(index);
        if (i >= 0 && i < skinColors.Count)
        {
            avatar.skinColor = skinColors[i];
            if (skinLayer != null)
                skinLayer.color = avatar.skinColor;
        }
    }

    // Cambia color de pelo según el índice del slider
    public void ChangeHairColor(float index)
    {
        int i = Mathf.RoundToInt(index);
        if (i >= 0 && i < hairColors.Count)
        {
            avatar.hairColor = hairColors[i];
            if (hairLayer != null)
                hairLayer.color = avatar.hairColor;
        }
    }

    public void ChangeHairStyle(int dropdownIndex)
    {
        if (hairDropdown == null) return;

        // Actualiza el nombre guardado
        string style = hairDropdown.options[dropdownIndex].text;
        avatar.hairStyle = style;

        // Usa la lista de sprites asignada en el inspector
        if (dropdownIndex >= 0 && dropdownIndex < hairSprites.Count && hairSprites[dropdownIndex] != null)
        {
            hairLayer.sprite = hairSprites[dropdownIndex];
        }
        else
        {
            Debug.LogWarning($"No hay sprite asignado en hairSprites[{dropdownIndex}]");
        }

        ApplyAvatar();
    }

    // Aplica todo el avatar visualmente
    public void ApplyAvatar()
    {
        if (skinLayer != null)
            skinLayer.color = avatar.skinColor;
        if (hairLayer != null)
            hairLayer.color = avatar.hairColor;
    }

    // Guarda cambios
    public void SaveAvatar()
    {
        AvatarManager.Instance.avatarData = avatar;
        AvatarManager.Instance.SaveAvatar();
    }
}

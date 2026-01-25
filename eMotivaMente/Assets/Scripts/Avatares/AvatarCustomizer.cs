using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AvatarCustomizer : MonoBehaviour
{
    public List<Sprite> hairSprites = new List<Sprite>();
    public List<Sprite> eyesSprites = new List<Sprite>();
    public List<Sprite> noseSprites = new List<Sprite>();
    public List<Sprite> mouthSprites = new List<Sprite>();
    public List<Sprite> browsSprites = new List<Sprite>();
    public List<Sprite> accesoriesSprites = new List<Sprite>();


    [Header("Capas")]
    public Image skinLayer;
    public Image hairLayer;
    public Image eyesLayer;
    public Image noseLayer;
    public Image mouthLayer;
    public Image browsLayer;
    public Image accesoriesLayer;

    [Header("Dropdowns de rasgos")]
    public TMP_Dropdown hairDropdown;
    public TMP_Dropdown eyesDropdown;
    public TMP_Dropdown noseDropdown;
    public TMP_Dropdown mouthDropdown;
    public TMP_Dropdown browsDropdown;
    public TMP_Dropdown accesoriesDropdown;

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

    public void ChangeAccesoriesStyle(int dropdownIndex)
    {
        if (accesoriesDropdown == null) return;

        // Actualiza el nombre guardado
        string style = accesoriesDropdown.options[dropdownIndex].text;
        avatar.accesories = style;

        // Usa la lista de sprites asignada en el inspector
        if (dropdownIndex >= 0 && dropdownIndex < accesoriesSprites.Count && accesoriesSprites[dropdownIndex] != null)
        {
            accesoriesLayer.sprite = accesoriesSprites[dropdownIndex];
        }
        else
        {
            Debug.LogWarning($"No hay sprite asignado en hairSprites[{dropdownIndex}]");
        }

        ApplyAvatar();
    }

    public void ChangeEyeStyle(int dropdownIndex)
    {
        if (eyesDropdown == null) return;

        // Actualiza el nombre guardado
        string style = eyesDropdown.options[dropdownIndex].text;
        avatar.eyes = style;

        // Usa la lista de sprites asignada en el inspector
        if (dropdownIndex >= 0 && dropdownIndex < eyesSprites.Count && eyesSprites[dropdownIndex] != null)
        {
            eyesLayer.sprite = eyesSprites[dropdownIndex];
        }
        else
        {
            Debug.LogWarning($"No hay sprite asignado en eyesSprites[{dropdownIndex}]");
        }

        ApplyAvatar();
    }

    public void ChangeBrowsStyle(int dropdownIndex)
    {
        if (browsDropdown == null) return;

        // Actualiza el nombre guardado
        string style = browsDropdown.options[dropdownIndex].text;
        avatar.brows = style;

        // Usa la lista de sprites asignada en el inspector
        if (dropdownIndex >= 0 && dropdownIndex < browsSprites.Count && browsSprites[dropdownIndex] != null)
        {
            browsLayer.sprite = browsSprites[dropdownIndex];
        }
        else
        {
            Debug.LogWarning($"No hay sprite asignado en eyesSprites[{dropdownIndex}]");
        }

        ApplyAvatar();
    }
    public void ChangeNoseStyle(int dropdownIndex)
    {
        if (noseDropdown == null) return;

        // Actualiza el nombre guardado
        string style = noseDropdown.options[dropdownIndex].text;
        avatar.eyes = style;

        // Usa la lista de sprites asignada en el inspector
        if (dropdownIndex >= 0 && dropdownIndex < noseSprites.Count && noseSprites[dropdownIndex] != null)
        {
            noseLayer.sprite = noseSprites[dropdownIndex];
        }
        else
        {
            Debug.LogWarning($"No hay sprite asignado en eyesSprites[{dropdownIndex}]");
        }

        ApplyAvatar();
    }

    public void ChangeMouthStyle(int dropdownIndex)
    {
        if (mouthDropdown == null) return;

        string style = mouthDropdown.options[dropdownIndex].text;
        avatar.mouth = style;


        if(dropdownIndex >= 0 && dropdownIndex < noseSprites.Count && mouthSprites[dropdownIndex] != null)
        {
            mouthLayer.sprite = mouthSprites[dropdownIndex];
        }
        else
        {
            Debug.LogWarning($"No hay sprites asignados en mouthSprites{dropdownIndex}");
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
        SceneManager.LoadScene("Menú del nivel 1");
    }
}

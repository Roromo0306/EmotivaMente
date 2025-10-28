using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarDisplay : MonoBehaviour
{
    public Image skinLayer;
    public Image hairLayer;
    public Image eyesLayer;
    public Image noseLayer;
    public Image mouthLayer;
    public Image browsLayer;
    public Image accesoriesLayer;

    // Start is called before the first frame update
    void Start()
    {
        AvatarData avatar = AvatarManager.Instance.avatarData;
        skinLayer.color = avatar.skinColor;
        hairLayer.color = avatar.hairColor;

        hairLayer.sprite = Resources.Load<Sprite>($"Hair/{avatar.hairStyle}");
        eyesLayer.sprite = Resources.Load<Sprite>($"Eyes/{avatar.eyes}");
        noseLayer.sprite = Resources.Load<Sprite>($"Nose/{avatar.nose}");
        mouthLayer.sprite = Resources.Load<Sprite>($"Mouth/{avatar.mouth}");
        browsLayer.sprite = Resources.Load<Sprite>($"Mouth/{avatar.brows}");
        accesoriesLayer.sprite = Resources.Load<Sprite>($"Mouth/{avatar.accesories}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

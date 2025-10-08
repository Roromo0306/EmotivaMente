using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public static AvatarManager Instance;

    public AvatarData avatarData = new AvatarData();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAvatar();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveAvatar()
    {
        string json = JsonUtility.ToJson(avatarData);
        PlayerPrefs.SetString("AvatarData", json);
        PlayerPrefs.Save();
    }

    public void LoadAvatar()
    {
        if (PlayerPrefs.HasKey("AvatarData"))
        {
            string json = PlayerPrefs.GetString("AvatarData");
            avatarData = JsonUtility.FromJson<AvatarData>(json);
        }
    }
}

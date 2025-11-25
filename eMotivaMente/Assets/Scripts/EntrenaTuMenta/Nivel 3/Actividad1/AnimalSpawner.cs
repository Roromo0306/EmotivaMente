using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject animalPrefab;
    public RectTransform spawnArea;

    public List<AnimalData> allAnimals;

    public List<AnimalData> GetRandomAnimals(int count)
    {
        return allAnimals
            .OrderBy(a => Random.value)
            .Take(count)
            .ToList();
    }

    public GameObject SpawnAnimal(AnimalData data)
    {
        GameObject obj = Instantiate(animalPrefab, spawnArea);

        AnimalBehaviour behaviour = obj.GetComponent<AnimalBehaviour>();
        behaviour.data = data;

        Sprite sprite = Resources.Load<Sprite>("Animals/" + data.spriteName);
        obj.GetComponent<Image>().sprite = sprite;

        RectTransform rt = obj.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(
            Random.Range(-spawnArea.rect.width / 2 + 50, spawnArea.rect.width / 2 - 50),
            Random.Range(-spawnArea.rect.height / 2 + 50, spawnArea.rect.height / 2 - 50)
        );

        return obj;
    }
}

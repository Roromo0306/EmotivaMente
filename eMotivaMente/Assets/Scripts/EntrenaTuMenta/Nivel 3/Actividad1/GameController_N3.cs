using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController_N3 : MonoBehaviour
{
    public AnimalSpawner spawner;
    public UIManager uiManager;

    public int totalAnimalsToShow = 20;
    public float displayTime = 7f;

    private int errors = 0;

    void Start()
    {
        StartCoroutine(RunGame());
    }

    IEnumerator RunGame()
    {
        errors = 0;

        List<AnimalData> randomAnimals = spawner.GetRandomAnimals(totalAnimalsToShow);

        foreach (var animal in randomAnimals)
        {
            GameObject obj = spawner.SpawnAnimal(animal);
            AnimalBehaviour behaviour = obj.GetComponent<AnimalBehaviour>();
            behaviour.controller = this;

            yield return new WaitForSeconds(displayTime);

            if (obj != null)
                Destroy(obj);
        }

        EvaluateResults();
    }

    public void RegisterSelection(AnimalData animal)
    {
        if (!animal.isDesert)
        {
            errors++;
            uiManager.ShowTemporaryMessage("¡Ups, hay un error!", 1.3f);
        }
    }

    void EvaluateResults()
    {
        if (errors == 0)
        {
            uiManager.ShowFinalMessage("¡Felicidades! No cometiste errores.", true);
        }
        else if (errors <= 3)
        {
            uiManager.ShowFinalMessage("Hay algunos errores, pero puedes continuar o repetir.", true);
        }
        else
        {
            uiManager.ShowFinalMessage("Demasiados errores. Vuelve a intentarlo.", false);
        }
    }
}

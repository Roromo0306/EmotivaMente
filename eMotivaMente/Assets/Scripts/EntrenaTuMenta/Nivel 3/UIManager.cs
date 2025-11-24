using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text statusText;
    public Text finalText;

    public Button retryButton;
    public Button nextButton;

    void Start()
    {
        finalText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }

    public void ShowTemporaryMessage(string msg, float time)
    {
        StartCoroutine(ShowTemp(msg, time));
    }

    IEnumerator ShowTemp(string msg, float time)
    {
        statusText.text = msg;
        yield return new WaitForSeconds(time);
        statusText.text = "";
    }

    public void ShowFinalMessage(string msg, bool canProceed)
    {
        finalText.text = msg;
        finalText.gameObject.SetActive(true);

        retryButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(canProceed);
    }
}

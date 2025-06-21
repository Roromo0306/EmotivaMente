using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SendToGoogle : MonoBehaviour
{
    public GameObject Name;
    public GameObject Edad;
    public GameObject Residencia;

    private string name;
    private string edad;
    private string residencia;

    [SerializeField] private string URL = "https://docs.google.com/forms/d/e/1FAIpQLSd8kaRT96vI1GBIKM6sgPQg9wxHfWvZeCaOb46VQ3jwTkI9rA/formResponse";

    IEnumerator Post(string name, string edad, string residencia)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.879726258", name);
        form.AddField("entry.1078649829", edad);
        form.AddField("entry.1719034656", residencia);

        byte[]rawData = form.data;
        WWW www = new WWW(URL, rawData);
        yield return www;


    }

    public void Send()
    {
        name = Name.GetComponent<TMP_InputField>().text;
        edad = Edad.GetComponent<TMP_InputField>().text;
        residencia = Residencia.GetComponent<TMP_InputField>().text;

        StartCoroutine(Post(name, edad, residencia));
        Debug.Log("Datos Enviados");

    }
}

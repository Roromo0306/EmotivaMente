using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObtenerDatos : MonoBehaviour
{
    // Referencias a los objetos de entrada (Input Fields) en la escena
    public GameObject Name;
    public GameObject Edad;
    public GameObject Residencia;

    // Variables para guardar los valores escritos en los Input Fields
    private string nombre;
    private string edad;
    private string residencia;

    public void obtener()
    {
        // Obtener los textos de cada Input Field, y eliminar espacios en blanco al inicio y final
        nombre = Name.GetComponent<TMP_InputField>().text.Trim();
        edad = Edad.GetComponent<TMP_InputField>().text.Trim();
        residencia = Residencia.GetComponent<TMP_InputField>().text.Trim();

        //Envia los datos al singleton
        DatosEmotivamente.Instance.Name = nombre;
        DatosEmotivamente.Instance.edad = edad;
        DatosEmotivamente.Instance.residencia = residencia;

        //Carga la siguiente escena
        SceneManager.LoadScene("Menú del nivel 1");

    }
}

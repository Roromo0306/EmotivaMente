using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SendToGoogle : MonoBehaviour
{
    // Referencias a los objetos de entrada (Input Fields) en la escena
    public GameObject Name;
    public GameObject Edad;
    public GameObject Residencia;

    // Texto para mostrar mensajes de estado al usuario
    public TextMeshProUGUI StatusText;

    // Variables para guardar los valores escritos en los Input Fields
    private string nombre;
    private string edad;
    private string residencia;

    // URL del formulario de Google Forms donde vamos a enviar los datos
    [SerializeField] private string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSd8kaRT96vI1GBIKM6sgPQg9wxHfWvZeCaOb46VQ3jwTkI9rA/formResponse";

    // Coroutine para enviar los datos al formulario mediante POST
    IEnumerator Post(string nombre, string edad, string residencia)
    {
        // Crear un formulario web para enviar los datos
        WWWForm form = new WWWForm();

        // Agregar campos con los entry IDs del formulario y valores de prueba (hardcodeados)
        form.AddField("entry.879726258", nombre);     // Campo nombre
        form.AddField("entry.1078649829", edad);           // Campo edad
        form.AddField("entry.1719034656", residencia);   // Campo residencia

        // Mostrar mensaje de que el envío está en proceso
        StatusText.text = "Enviando...";

        // Crear y enviar la solicitud POST a la URL del formulario con los datos
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();  // Esperar a que termine el envío

        // Revisar si hubo error en el envío
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al enviar: " + www.error);   // Mostrar error en consola
            StatusText.text = "Error al enviar.";               // Mostrar error en pantalla
        }
        else
        {
            Debug.Log("¡Datos enviados con éxito!");            // Confirmación en consola
            StatusText.text = "¡Enviado correctamente!";       // Confirmación en pantalla

            // Limpiar los campos de texto para nueva entrada
            Name.GetComponent<TMP_InputField>().text = "";
            Edad.GetComponent<TMP_InputField>().text = "";
            Residencia.GetComponent<TMP_InputField>().text = "";
        }
    }

    // Función que se llama cuando el usuario quiere enviar los datos (ejemplo: botón)
    public void Send()
    {
        // Obtener los textos de cada Input Field, y eliminar espacios en blanco al inicio y final
        nombre = Name.GetComponent<TMP_InputField>().text.Trim();
        edad = Edad.GetComponent<TMP_InputField>().text.Trim();
        residencia = Residencia.GetComponent<TMP_InputField>().text.Trim();

        // Validar que no haya campos vacíos; si alguno está vacío, mostrar advertencia y no enviar
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(residencia))
        {
            Debug.LogWarning("Por favor, completa todos los campos.");  // Aviso en consola
            StatusText.text = "Por favor, completa todos los campos.";  // Aviso visible en UI
            return;  // Salir sin hacer nada más
        }

        // Iniciar la coroutine para enviar los datos al formulario
        StartCoroutine(Post(nombre, edad, residencia));
    }
}



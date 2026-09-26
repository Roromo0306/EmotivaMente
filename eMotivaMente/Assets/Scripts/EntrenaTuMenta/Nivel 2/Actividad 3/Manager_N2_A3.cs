using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N2_A3 : MonoBehaviour
{
    [Header("Listas")]
    public List<Sprite> ejemplos; //Lista con los sprites de ejemplo
    public List<Sprite> actividad; //Lista con los sprites de actividad

    [Header("Escalas actividad")]
    public List<Vector3> escalasActividad = new List<Vector3>
{
    new Vector3(1.64f, 1.64f, 1.64f), // Abrigo
    new Vector3(1.05f, 1.05f, 1.05f), // Bañador
    new Vector3(1.12f, 1.5f, 1.5f),   // Biquini
    new Vector3(1.08f, 1.08f, 1.08f), // Bota
    new Vector3(1.08f, 1.08f, 1.08f), // Bufanda
    new Vector3(0.73f, 0.73f, 0.73f), // Calcetines
    new Vector3(1.69f, 1.69f, 1.69f), // Camisa
    new Vector3(1.69f, 1.69f, 1.69f), // Camiseta
    new Vector3(1.69f, 1.69f, 1.69f), // CamistaL
    new Vector3(1.69f, 1.69f, 1.69f), // Cazadora
    new Vector3(0.91f, 0.91f, 0.91f), // Chanclas
    new Vector3(0.91f, 0.6f, 0.91f),   // GafasSol
    new Vector3(1.26f, 0.91f, 0.91f),  // GorraS
    new Vector3(0.93f, 0.93f, 0.93f), // Gorro
    new Vector3(0.87f, 0.87f, 0.87f), // Guantes
    new Vector3(1.71f, 1.71f, 1.71f), // Jersey
    new Vector3(0.92f, 0.92f, 0.92f), // Manoplas
    new Vector3(1.81f, 1.81f, 1.81f), // Pantalón
    new Vector3(1.71f, 1.71f, 1.71f), // Sueter
    new Vector3(1.11f, 1.11f, 1.11f)  // Zapatos
};

    [Header("Escalas ejemplo")]
    public List<Vector3> escalasEjemplo = new List<Vector3>
{
    new Vector3(0.76f, 0.76f, 0.76f), // Calcetines
    new Vector3(1.11f, 1.11f, 1.11f), // Chanclas
    new Vector3(1.21f, 1.21f, 1.21f), // Gorro
    new Vector3(1.45f, 1.77f, 1.77f)  // Vestido
};

    [Header("Canvas")]
    public Canvas CanvasMenu; //Lista con los sprites de canva

    [Header("Generador")]
    public GameObject generador; //Referencia al generador
    public Image imagenGenerador; //Referencia a la imagen del generador

    public int contador = 0; //Contador que nos ayudara a saber cuantos elementos se han sacado

    private Vector3 originalPosition; //Vector que guardara la posicion original

    private bool corrutina = true; //Bool que nos marcara si se puede activar una nueva corrutina
    [HideInInspector] public bool actTerminada = false; //Bool que nos marcara si la actividad ha terminado
    void Start()
    {
        imagenGenerador = generador.GetComponent<Image>();

        originalPosition = generador.transform.position;
    }


    void Update()
    {
        CanvasMenu_N2_A3 can = CanvasMenu.GetComponent<CanvasMenu_N2_A3>();

        if (can.modo == 1)
        {
            if (corrutina)
            {
                StopAllCoroutines();//Paro todas las corrutinas activas en ese momento
                Time.timeScale = 1; //Activo el tiempo en 1 por si estaba parado

                StartCoroutine(EjemploA3()); //Empiezo la corrutina
                corrutina = false;
            }

            if (contador >= 4)
            {
                //Reinicio de variables
                contador = 0;
                can.modo = 0;
                corrutina = true;
                can.Audio.gameObject.SetActive(true);
                CanvasMenu.enabled = true;
                Time.timeScale = 0;
            }
        }

        if (can.modo == 2)
        {
            if (corrutina)
            {
                StopAllCoroutines(); //Paro todas las corrutinas activas en ese momento
                Time.timeScale = 1; //Activo el tiempo en 1 por si estaba parado

                StartCoroutine(ActividadA3()); //Empiezo la corrutina
                corrutina = false;
            }

            if (contador >= 20)
            {
                //Reinicio de variables
                contador = 0;
                can.modo = 0;
                corrutina = true;

                actTerminada = true;
                CanvasMenu.enabled = true;
                Time.timeScale = 0;

            }
        }
    }

    //Corrutina del ejemplo
    public IEnumerator EjemploA3()
    {
        contador = 0;

        for (int i = 0; i < ejemplos.Count; i++)
        {
            // Cambiar sprite
            imagenGenerador.sprite = ejemplos[i];

            // Restaurar posición
            generador.transform.position = originalPosition;

            // Cambiar escala
            generador.transform.localScale = escalasEjemplo[i];

            yield return new WaitForSeconds(10f);

            contador++;
        }

        yield break;
    }

    //Corrutina de la actividad
    public IEnumerator ActividadA3()
    {
        contador = 0;

        for (int i = 0; i < actividad.Count; i++)
        {
            // Cambiar sprite
            imagenGenerador.sprite = actividad[i];

            // Restaurar posición
            generador.transform.position = originalPosition;

            // Cambiar escala
            generador.transform.localScale = escalasActividad[i];

            yield return new WaitForSeconds(10f);

            contador++;
        }

        yield break;
    }
}

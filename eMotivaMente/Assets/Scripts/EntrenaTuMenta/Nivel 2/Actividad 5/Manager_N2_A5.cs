using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N2_A5 : MonoBehaviour
{
    [Header("Canvas")] //Canva menu
    public Canvas canvas;

    [Header("Listas")] //Listas donde guardo las imagenes que van apareciendo
    public List<GameObject> ImagenesAct;
    public List<GameObject> ImagenesEj;

    [Header("Slots")] //Huecos donde se encajan las imagenes
    public ItemSlot[] SlotsAct;
    public ItemSlot[] SlotsEj;

    [Header("Gameobject Actividad")] //Gameobject que agrupa a los huecos de la actividad
    public GameObject slotsActividad;

    [Header("Gameobject Ejemplo")] //Gameobject que agrupa a los huecos del ejemplo
    public GameObject slotsEjemplo;

    [Header("Botones")] //Botones
    public Button botonAct;
    public Button botonEj;

    [HideInInspector] public int score = 0; //Puntuacion
    private bool Actividad = false, Ejemplo = false; //Boleanos para controlar que se llame a la corrutina una vez
    private int contador = 0; //Contador para evitar errores a la hora de generar imagenes
    [HideInInspector] public bool Terminado = false; //Boleano para indicar que se ha terminado la actividad

    private void Update()
    {
        CanvasMenu_N2_A5 can = canvas.GetComponent<CanvasMenu_N2_A5>(); //Referencia al canvas emnu

        //Modo ejemplo
        if(can.modo == 1)
        {
            if (!Ejemplo)
            {
                //Activo los dos componentes del ejemplo
                slotsEjemplo.gameObject.SetActive(true); 
                botonEj.gameObject.SetActive(true);

                //Activo la corrutina que genera las imagenes del ejemplo
                StartCoroutine(AparecerEJ());

                //Activo este boleano para que todo se llame una vez
                Ejemplo = true;
            }
        }

        //Modo actividad
        if(can.modo == 2)
        {
            if (!Actividad)
            {
                //Activo los dos componentes de la actividad
                slotsActividad.gameObject.SetActive(true);
                botonAct.gameObject.SetActive(true);

                //Activo la corrutina que genera las imagenes de la actividad
                StartCoroutine(AparecerAct());

                //Activo este boleano para que todo se llame una vez
                Actividad = true;
            }
        }
    }

    //ACTIVIDAD//
    IEnumerator AparecerAct() //Corrutina que genera las imagenes
    {
        while (contador <= ImagenesAct.Count -1) //Indico que se repita por el numero de imagenes total que hay en la lista
        {
            yield return new WaitForSeconds(3f); //Espero 10 segundos
            Debug.Log("hola");
            ImagenesAct[contador].gameObject.SetActive(true); //Activo la imagen
            contador++; //Aumento esta variable
        }

        StopAllCoroutines(); //Al acabar el bucle llamo a esto para detener la corrutina
    }

    public void CheckSlots() //Funcion que se encargara de revisar que las imagenes esten en sus huecos correspondientes
    {
        CanvasMenu_N2_A5 can = canvas.GetComponent<CanvasMenu_N2_A5>();

        //Reseteo estas dos variables
        score = 0;
        contador = 0;

        for (int i = 0; i < SlotsAct.Length; i++) //Recorre todos los huecos
        {
            if (SlotsAct[i].transform.childCount > 0) //Detecta que hay un hijo en el gameobject del huevo
            {
                GameObject objHijo = SlotsAct[i].transform.GetChild(0).gameObject; //Guarda en objHijo el objeto hijo
                DragAndDrop dr = objHijo.GetComponent<DragAndDrop>(); //Referencia al codigo

                if (dr.itemID == SlotsAct[i].slotID) //Si los ID coinciden, score aumenta
                {
                    score++;
                }
            }
        }

        Debug.Log(score);

        //Desactivo estos componentes
        slotsActividad.gameObject.SetActive(false);
        botonAct.gameObject.SetActive(false);

        //Activo este bool para indicar al canvas que ya se ha terminado la actividad
        Terminado = true;

        //Vuelve al canvas menu y resetea el modo
        canvas.enabled = true;
        can.modo = 0;
    }

    //EJEMPLO//
    IEnumerator AparecerEJ() //Corrutina que genera las imagenes
    {
        while (contador <= ImagenesEj.Count - 1) //Indico que se repita por el numero de imagenes total que hay en la lista
        {
            yield return new WaitForSeconds(10f); //Espero 10 segundos
            ImagenesEj[contador].gameObject.SetActive(true); //Activo la imagen
            contador++; //Aumento esta variable
        }

        

        StopAllCoroutines(); //Al acabar el bucle llamo a esto para detener la corrutina
    }

    public void CheckSlotsEJ() //Funcion que se encargara de revisar que las imagenes esten en sus huecos correspondientes
    {
        CanvasMenu_N2_A5 can = canvas.GetComponent<CanvasMenu_N2_A5>();

        //Reseteo estas dos variables
        score = 0;
        contador = 0;

        for (int i = 0; i < SlotsEj.Length; i++) //Recorre todos los huecos
        {
            if (SlotsEj[i].transform.childCount > 0) //Detecta que hay un hijo en el gameobject del huevo
            {
                GameObject objHijo = SlotsEj[i].transform.GetChild(0).gameObject; //Guarda en objHijo el objeto hijo
                DragAndDrop dr = objHijo.GetComponent<DragAndDrop>(); //Referencia al codigo

                if (dr.itemID == SlotsEj[i].slotID) //Si los ID coinciden, score aumenta
                {
                    score++;
                }
            }
        }

        Debug.Log(score);


        //Desactivo estos componentes
        slotsEjemplo.gameObject.SetActive(false);
        botonEj.gameObject.SetActive(false);

        //Vuelve al canvas menu y resetea el modo
        can.Audio.gameObject.SetActive(true);
        canvas.enabled = true;
        can.modo = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N2_A2 : MonoBehaviour
{
    [Header("Listas")]
    public List<Sprite> ejemplos; //Lista con los sprites de ejemplo
    public List<Sprite> actividad; //Lista con los sprites de actividad

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
        CanvasMenu_N2_A2 can = CanvasMenu.GetComponent<CanvasMenu_N2_A2>();

        if(can.modo == 1)
        {
            if (corrutina)
            {
                StopAllCoroutines();//Paro todas las corrutinas activas en ese momento
                Time.timeScale = 1; //Activo el tiempo en 1 por si estaba parado

                StartCoroutine(EjemploA2()); //Empiezo la corrutina
                corrutina = false;
            }
            
            if(contador >= 4)
            {
                //Reinicio de variables
                contador = 0;
                can.modo = 0;
                corrutina = true;
                CanvasMenu.enabled = true;
                Time.timeScale = 0;
            }
        }

        if(can.modo == 2)
        {
            if (corrutina)
            {
                StopAllCoroutines(); //Paro todas las corrutinas activas en ese momento
                Time.timeScale = 1; //Activo el tiempo en 1 por si estaba parado

                StartCoroutine(ActividadA2()); //Empiezo la corrutina
                corrutina = false;
            }
            
            if(contador >= 20)
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
    public IEnumerator EjemploA2()
    {
        contador = 0; //Reinicio el contador

        foreach(var sprite in ejemplos)
        { 
            imagenGenerador.sprite = sprite; //Pongo la imagen del sprite 
            generador.transform.position = originalPosition; //Reposiciono la imagen en su lugar original
            
            yield return new WaitForSeconds(10f);
            contador++;
        }

        yield break;
    }

    //Corrutina de la actividad
    public IEnumerator ActividadA2()
    {
        contador = 0; //Reinicio el contador

        foreach(var sprite in actividad)
        {
            imagenGenerador.sprite = sprite; //Pongo la imagen del sprite 
            generador.transform.position = originalPosition; //Reposiciono la imagen en su lugar original

            yield return new WaitForSeconds(10f);
            contador++;
        }

        yield break;
    }
}

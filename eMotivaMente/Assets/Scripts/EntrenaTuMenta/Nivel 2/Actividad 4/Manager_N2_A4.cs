using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_N2_A4 : MonoBehaviour
{
    [Header("Lista")]
    public List<Sprite> ImagenesSprite;
    public List<GameObject> Imagenes;
    public List<Sprite> ImagenesSpriteEj;
    public List<GameObject> ImagenesEj;

    [Header("Canva")]
    public Canvas canvaMenu;

    [Header("Boton")]
    public Button boton;
    public Button botonEj;

    [Header("GameObject Ejemplo")]
    public GameObject textosNumEj;
    public GameObject textosInstrucEj;
    public GameObject GeneradorEj;

    [Header("GameObject Actividad")]
    public GameObject textosNumAct;
    public GameObject textosInstrucAct;
    public GameObject GeneradorAct;

    private bool ejemplo = false, actividad = false; //Bool para iniciar una sola vez el ejemplo o la actividad
    public int Paso = 0, indice = 0; //Enteros para controlar las listas

    //Cronometro
    private bool crono = false;
    public float Cronometro = 0;

    void Update()
    {
        if (crono)
        {
            Cronometro += Time.deltaTime;
        }

        CanvasMenu_N2_A4 can = canvaMenu.GetComponent<CanvasMenu_N2_A4>(); //Referencia al canvas

        //Ejemplo
        if(can.modo == 1)
        {
            if (!ejemplo)
            {
                //Activo los diferentes componenetes del ejemplo
                textosNumEj.SetActive(true);
                textosInstrucEj.SetActive(true);
                GeneradorEj.SetActive(true);

                StartCoroutine(CicloImagenesEj()); //Activo la corrutina
                ejemplo = true; //Activo el booleano para que esto se ejecute una vez
            }

            //Victoria del ejemplo
            if(indice >= 3)
            {
                //Reseteo indice y paso
                indice = 0;
                Paso = 0;
               
                //Hago un bucle para ocultar las imagenes que se habian mostrado
                for (int i = 0; i < ImagenesEj.Count; i++)
                {
                    ImagenesEj[i].gameObject.SetActive(false);
                }

                //Reseteo la varible modo
                can.modo = 0; 

                //Paro todas las corrutinas
                StopAllCoroutines();

                //Desactivo todos los componentes del ejemplo
                textosNumEj.SetActive(false);
                textosInstrucEj.SetActive(false);
                GeneradorEj.SetActive(false);
                can.Audio.gameObject.SetActive(true);

                //Reactivo el canvas
                canvaMenu.enabled = true;
            }
        }

        //Actividad
        if (can.modo == 2)
        {
            if (!actividad)
            {
                //Activo todos los componentes de la actividad
                textosNumAct.SetActive(true);
                textosInstrucAct.SetActive(true);
                GeneradorAct.SetActive(true);

                StopAllCoroutines();

                //Activo la corrutina
                StartCoroutine(CicloImagenes());
                crono = true;

                //Pongo true el booleano para que no se repita mas este componente
                actividad = true;
            }

            //Victoria Actividad
            if (indice >= 8)
            {
                //Reseteo indice y paso
                indice = 0;
                Paso = 0;
                crono = false;

                //Recorro la lista para desactivar las imagenes que habian salido
                for (int i = 0; i < Imagenes.Count; i++)
                {
                    Imagenes[i].gameObject.SetActive(false);
                }

                //Reseteo la variable modo
                can.modo = 0;

                //Paro todas las corrutinas
                StopAllCoroutines();

                //Desactivo el generador
                GeneradorAct.gameObject.SetActive(false);

                //Activo el canvas
                canvaMenu.enabled = true;
            }
        }


    }

    //Ejemplo//
    IEnumerator CicloImagenesEj() //Corrutina que se encargara de cambiar cada imagen del generador
    {
        while (indice < 3)
        {
            botonEj.image.sprite = ImagenesSpriteEj[Paso]; //Aplico la imagen de la lista en el sprite

            yield return new WaitForSeconds(10f); //Espero 10 segundos

            if (Paso < ImagenesSpriteEj.Count - 1) //Mientras no haya llegado al final paso aumenta en uno
            {
                Paso++;
            }
            else //Si llega al final paso vuelve a 0 para que se recorra la lista de nuevo
            {
                Paso = 0;
            }
        }

        yield break;
    }

    public void ComprobarEj() //Funcion asociado al boton que comprueba si la imagen que aparece es la que toca
    {

        if (botonEj.image.sprite.name == indice.ToString()) //Compara el nombre del sprite del boton con el valor del indice
        {
            ImagenesEj[indice].SetActive(true);
            indice++;
        }
    }


    //Actividad//
    IEnumerator CicloImagenes() //Corrutina que se encargara de cambiar cada imagen del generador
    {
        while (indice < 8) 
        { 
            boton.image.sprite = ImagenesSprite[Paso]; //Aplico la imagen de la lista en el sprite

            yield return new WaitForSeconds(10f); //Espero 10 segundos

            textosInstrucAct.gameObject.SetActive(false); //Desactivo los textos 

            if (Paso < ImagenesSprite.Count -1) //Mientras no haya llegado al final paso aumenta en uno
            {
                Paso++;
            }
            else //Si llega al final paso vuelve a 0 para que se recorra la lista de nuevo
            {
                Paso = 0;
            }
        }

        yield break;
    }

    public void Comprobar() //Funcion asociado al boton que comprueba si la imagen que aparece es la que toca
    {
       
        if(boton.image.sprite.name == indice.ToString()) //Compara el nombre del sprite del boton con el valor del indice
        {
            Imagenes[indice].SetActive(true);
            indice++;
        }
    }
}

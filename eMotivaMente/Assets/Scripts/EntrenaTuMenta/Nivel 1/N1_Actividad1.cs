using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class N1_Actividad1 : MonoBehaviour
{
    // Imagen que se usará como cursor
    public RectTransform cursorImage;

    // Contenedor donde instanciar las imágenes
    public GameObject generador;
    // Lista de sprites a mostrar
    public List<Sprite> imagenes;

    // Prefab de Image UI que usaremos para mostrar los sprites
    public GameObject imagePrefab;

    void Start()
    {
        Cursor.visible = false; // Oculta el cursor del sistema

        // Iniciar la corrutina de generación
        StartCoroutine(Act1());
    }

    void Update()
    {
        // Hace que la imagen siga al cursor
        Vector2 pos = Input.mousePosition;
        cursorImage.position = pos;
    }

    private IEnumerator Act1()
    {
        // Bucle infinito que recorre la lista
        while (true)
        {
            foreach (Sprite sprite in imagenes)
            {
                // Instancia el prefab como hijo de "generador"
                GameObject instancia = Instantiate(imagePrefab, generador.transform);

                // Asigna el sprite al componente Image del prefab
                Image imgComponent = instancia.GetComponent<Image>();
                if (imgComponent != null)
                {
                    imgComponent.sprite = sprite;
                }

                // Espera 7 segundos
                yield return new WaitForSeconds(7f);

                // Destruye la instancia antes de pasar a la siguiente
                Destroy(instancia);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Ejemplo_Col : MonoBehaviour
{
    private GameObject esto;
    private SpriteRenderer sp;

    public bool parada = false;

    public GameObject manager;
    private void Start()
    {
        esto = this.gameObject;
        sp = esto.GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Manager_N1_A2 m = manager.GetComponent<Manager_N1_A2>();
        if(collision.gameObject.name == "Caja")
        {
            parada = true;
            Debug.Log("Caja");
        }

        if(collision.gameObject.name == "Plato")
        {
            parada = true;
            Debug.Log("Plato");
        }

    }
}

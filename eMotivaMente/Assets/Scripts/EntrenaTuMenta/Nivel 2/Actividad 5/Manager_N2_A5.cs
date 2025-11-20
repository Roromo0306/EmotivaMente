using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_N2_A5 : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canvas;

    [Header("Listas")]
    public List<GameObject> ImagenesAct;
    public List<GameObject> ImagenesEj;

    [Header("Slots")]
    public ItemSlot[] allSlots;

    [HideInInspector] public int score = 0;
    private bool Actividad = false;

    private void Update()
    {
        CanvasMenu_N2_A5 can = canvas.GetComponent<CanvasMenu_N2_A5>();

        if(can.modo == 2)
        {
            if (!Actividad)
            {
                StartCoroutine(Aparecer());
                Actividad = true;
            }
        }
    }

    IEnumerator Aparecer()
    {
        //Poner un While
        yield return new WaitForSeconds(2f);
        //Al terminar el while llamar a stop corrutine
    }

    public void CheckSlots()
    {
        score = 0;

        for (int i = 0; i < allSlots.Length; i++)
        {
            if (allSlots[i].transform.childCount > 0)
            {
                GameObject objHijo = allSlots[i].transform.GetChild(0).gameObject;
                DragAndDrop dr = objHijo.GetComponent<DragAndDrop>();

                if (dr.itemID == allSlots[i].slotID)
                {
                    score++;
                }
            }
        }

        Debug.Log(score);
    }
}

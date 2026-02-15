using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_N4_A5 : MonoBehaviour
{
    public enum Modo { Ninguno, Ejemplo, Actividad }
    public Modo modoActual = Modo.Ninguno;

    [Header("Spawns")]
    public Transform spawnArriba;
    public Transform spawnAbajo;

    [Header("Prefabs")]
    public List<GameObject> prefabsArriba;
    public List<GameObject> prefabsAbajo;

    private GameObject prendaArribaActual;
    private GameObject prendaAbajoActual;

    private bool arribaCorrecto = false;
    private bool abajoCorrecto = false;

    public int errores = 0;

    public Canvas canvasInicio;

    public void IniciarEjemplo()
    {
        Debug.Log("[MODO] Ejemplo");
        ReiniciarVariables();
        modoActual = Modo.Ejemplo;
        StartCoroutine(SpawnPrendas());
    }

    public void IniciarActividad()
    {
        Debug.Log("[MODO] Actividad");
        ReiniciarVariables();
        modoActual = Modo.Actividad;
        StartCoroutine(SpawnPrendas());
    }

    IEnumerator SpawnPrendas()
    {
        Debug.Log("[SPAWN] Iniciando spawn");

        while (!(arribaCorrecto && abajoCorrecto))
        {
            LimpiarPrendas();

            prendaArribaActual = Instantiate(
                prefabsArriba[Random.Range(0, prefabsArriba.Count)],
                spawnArriba
            );

            prendaAbajoActual = Instantiate(
                prefabsAbajo[Random.Range(0, prefabsAbajo.Count)],
                spawnAbajo
            );

            prendaArribaActual.transform.localPosition = Vector3.zero;
            prendaAbajoActual.transform.localPosition = Vector3.zero;

            Debug.Log("[SPAWN] Prendas generadas");

            yield return new WaitForSeconds(3f);
        }

        Evaluar();
    }

    public void ColocarPrenda(Prenda prenda, bool zonaArriba)
    {
        Debug.Log($"[VALIDAR] {prenda.name}");

        bool correcto = false;

        if (modoActual == Modo.Ejemplo)
        {
            correcto = prenda.esArriba == zonaArriba;
            Debug.Log("[EJEMPLO] Solo se valida posición");
        }
        else
        {
            if (prenda.esArriba != zonaArriba)
            {
                Debug.Log("[ERROR] Zona incorrecta");
            }
            else if (zonaArriba && !prenda.esRoja)
            {
                Debug.Log("[ERROR] Arriba no es roja");
            }
            else if (!zonaArriba && !prenda.esAzul)
            {
                Debug.Log("[ERROR] Abajo no es azul");
            }
            else
            {
                correcto = true;
            }
        }

        if (correcto)
        {
            Debug.Log("[OK] Prenda correcta");

            if (zonaArriba) arribaCorrecto = true;
            else abajoCorrecto = true;
        }
        else
        {
            errores++;
            Debug.Log($"[FALLO] Total errores: {errores}");
        }

        Destroy(prenda.gameObject);
    }

    void Evaluar()
    {
        Debug.Log($"[FIN] Errores: {errores}");

        canvasInicio.enabled = true;

        if (errores == 0)
            Debug.Log("[RESULTADO] PERFECTO");
        else if (errores <= 2)
            Debug.Log("[RESULTADO] BIEN CON ERRORES");
        else
            Debug.Log("[RESULTADO] REPETIR");
    }

    void LimpiarPrendas()
    {
        if (prendaArribaActual != null)
            Destroy(prendaArribaActual);

        if (prendaAbajoActual != null)
            Destroy(prendaAbajoActual);
    }

    void ReiniciarVariables()
    {
        StopAllCoroutines();
        LimpiarPrendas();
        arribaCorrecto = false;
        abajoCorrecto = false;
        errores = 0;
    }

    public void Reiniciar()
    {
        ReiniciarVariables();
        modoActual = Modo.Ninguno;
    }
}
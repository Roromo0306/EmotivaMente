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

    // ------------------- INICIO EJEMPLO Y ACTIVIDAD -------------------

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

    // ------------------- SPAWN DE PRENDAS -------------------

    IEnumerator SpawnPrendas()
    {
        Debug.Log("[SPAWN] Iniciando spawn");

        while (!(arribaCorrecto && abajoCorrecto))
        {
            LimpiarPrendas();

            // SPAWN ARRIBA
            prendaArribaActual = Instantiate(
                prefabsArriba[Random.Range(0, prefabsArriba.Count)],
                spawnArriba
            );
            prendaArribaActual.transform.localPosition = Vector3.zero;

            // SPAWN ABAJO
            prendaAbajoActual = Instantiate(
                prefabsAbajo[Random.Range(0, prefabsAbajo.Count)],
                spawnAbajo
            );
            prendaAbajoActual.transform.localPosition = Vector3.zero;

            Debug.Log("[SPAWN] Prendas generadas");

            yield return new WaitForSeconds(3f);
        }

        Evaluar();
    }

    // ------------------- COLOCAR PRENDA -------------------

    public void ColocarPrenda(Prenda prenda, bool zonaArriba)
    {
        bool correcto = false;

        if (modoActual == Modo.Ejemplo)
        {
            correcto = prenda.esArriba == zonaArriba;
            Debug.Log("[EJEMPLO] Validando posición: " + correcto);
        }
        else
        {
            // ACTIVIDAD: validar color y posición
            if (prenda.esArriba != zonaArriba)
            {
                Debug.Log("[ERROR] Zona incorrecta");
            }
            else if (zonaArriba && !prenda.esRoja)
            {
                Debug.Log("[ERROR] Parte ARRIBA no es roja");
            }
            else if (!zonaArriba && !prenda.esAzul)
            {
                Debug.Log("[ERROR] Parte ABAJO no es azul");
            }
            else
            {
                correcto = true;
            }
        }

        // Actualizamos solo la zona correspondiente
        if (correcto)
        {
            if (zonaArriba) arribaCorrecto = true;
            else abajoCorrecto = true;

            Debug.Log("[OK] Prenda correcta en zona: " + (zonaArriba ? "ARRIBA" : "ABAJO"));
        }
        else
        {
            errores++;
            Debug.Log("[FALLO] Error número " + errores + " en zona: " + (zonaArriba ? "ARRIBA" : "ABAJO"));
        }

        Destroy(prenda.gameObject);
    }

    // ------------------- EVALUAR RESULTADO -------------------

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

    // ------------------- LIMPIEZA -------------------

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
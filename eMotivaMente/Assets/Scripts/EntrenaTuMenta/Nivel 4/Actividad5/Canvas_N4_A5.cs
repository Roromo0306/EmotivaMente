using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas_N4_A5 : MonoBehaviour
{
    public GameObject panelMenu;

    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;

    public Manager_N4_A5 manager;

    void Start()
    {
        Ejemplo.onClick.AddListener(EjemploF);
        Actividad.onClick.AddListener(ActividadF);
        Reintentar.onClick.AddListener(ReintentarF);
        Menu.onClick.AddListener(MenuF);

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
    }

    void EjemploF()
    {
        panelMenu.SetActive(false);
        manager.IniciarEjemplo();
    }

    void ActividadF()
    {
        panelMenu.SetActive(false);
        manager.IniciarActividad();
    }

    void ReintentarF()
    {
        panelMenu.SetActive(false);
        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);

        manager.ReiniciarActividad();
    }

    void MenuF()
    {
        SceneManager.LoadScene("MenuNivel5");
    }

    public void MostrarResultado(bool mostrarMenu, bool mostrarReintentar)
    {
        panelMenu.SetActive(true);

        Menu.gameObject.SetActive(mostrarMenu);
        Reintentar.gameObject.SetActive(mostrarReintentar);

        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasN4_A1 : MonoBehaviour
{
    [Header("Panel Menú")]
    public GameObject panelMenu;

    [Header("Botones")]
    public Button Ejemplo;
    public Button Actividad;
    public Button Reintentar;
    public Button Menu;
    public Button Audio;

    [Header("Manager")]
    public ManagerN4_A1 manager;

    public AudioSource fuenteAudio;

    void Start()
    {
        Ejemplo.onClick.AddListener(EjemploF);
        Actividad.onClick.AddListener(ActividadF);
        Reintentar.onClick.AddListener(ReintentarF);
        Menu.onClick.AddListener(MenuF);
        Audio.onClick.AddListener(Sonido);

        Reintentar.gameObject.SetActive(false);
        Menu.gameObject.SetActive(false);
    }

    void Sonido()
    {
        fuenteAudio.Play();
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
        SceneManager.LoadScene("MenuNivel4");
    }

    // 👉 llamado desde el Manager al finalizar
    public void MostrarMenuFinal(bool mostrarMenu, bool mostrarReintentar)
    {
        panelMenu.SetActive(true);

        Menu.gameObject.SetActive(mostrarMenu);
        Reintentar.gameObject.SetActive(mostrarReintentar);

        Ejemplo.gameObject.SetActive(false);
        Actividad.gameObject.SetActive(false);
    }
}

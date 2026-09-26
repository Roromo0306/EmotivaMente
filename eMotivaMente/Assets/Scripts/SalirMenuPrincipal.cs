using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirMenuPrincipal : MonoBehaviour
{
    public void VolverMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

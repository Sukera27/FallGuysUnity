using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void escenaJuego()
    {
        SceneManager.LoadScene("Juego");
    }
    public void salir()
    {
        Application.Quit();
    }
}

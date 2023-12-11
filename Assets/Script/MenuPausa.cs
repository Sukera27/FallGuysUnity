using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    

    // GameObject del menú de pausa.
    [SerializeField] private GameObject menuPausa;

    // Variable para controlar si el juego está pausado o no.
    private bool juegoPausado = false;

    // Método Update se llama una vez por frame.
    private void Update()
    {
        // Configura el cursor en modo visible y sin bloqueo.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Verifica si se presiona la tecla Escape.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si el juego está pausado, reanuda; de lo contrario, pausa el juego.
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    // Pausa el juego.
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f; // Detiene el tiempo en el juego.
        
        menuPausa.SetActive(true); // Activa el menú de pausa.
    }

    // Reanuda el juego.
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Restablece el tiempo en el juego.
        
        menuPausa.SetActive(false); // Desactiva el menú de pausa.
    }

    // Reinicia la escena actual.
    public void Reinicar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Restablece el tiempo en el juego.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual.
    }

 
}

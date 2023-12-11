using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    

    // GameObject del men� de pausa.
    [SerializeField] private GameObject menuPausa;

    // Variable para controlar si el juego est� pausado o no.
    private bool juegoPausado = false;

    // M�todo Update se llama una vez por frame.
    private void Update()
    {
        // Configura el cursor en modo visible y sin bloqueo.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Verifica si se presiona la tecla Escape.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si el juego est� pausado, reanuda; de lo contrario, pausa el juego.
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
        
        menuPausa.SetActive(true); // Activa el men� de pausa.
    }

    // Reanuda el juego.
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Restablece el tiempo en el juego.
        
        menuPausa.SetActive(false); // Desactiva el men� de pausa.
    }

    // Reinicia la escena actual.
    public void Reinicar()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Restablece el tiempo en el juego.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual.
    }

 
}

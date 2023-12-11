using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    // Variable pública para establecer la duración inicial del temporizador en segundos.
     public float timer = 120f;
    // Referencia al objeto TextMeshProUGUI utilizado para mostrar el tiempo restante.
     public TextMeshProUGUI textoTimer;

    private int minutos, segundos;
    // Referencia al objeto GameObject que se activará cuando el temporizador alcance cero.
     public GameObject perder;
    
    private void Update()
    {
        // Verifica si el temporizador aún está en marcha.
        if (timer > 0)
        {
            // Reduce el temporizador utilizando el tiempo transcurrido desde el último frame.
            timer -= Time.deltaTime;

            // Calcula minutos y segundos a partir del tiempo restante.
            minutos = (int)(timer / 60f);
            segundos = (int)(timer - minutos * 60f);
            // Actualiza el texto que muestra el tiempo formateado.
            textoTimer.text = "Tiempo: " + string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        else
        {
            // Si el temporizador ha alcanzado cero, activa el objeto de pérdida.
            perder.SetActive(true);
            // Pausa el tiempo en el juego.
            Time.timeScale = 0f;
            // Hace visible el cursor y lo desbloquea.
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

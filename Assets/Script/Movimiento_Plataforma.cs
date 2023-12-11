using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Plataforma : MonoBehaviour
{
    public float amplitud = 2f;    // Amplitud del movimiento en el eje Y
    public float velocidad = 2f;   // Velocidad de movimiento de la plataforma
    public float limiteSuperior = 1f;   // L�mite superior de movimiento (ajusta seg�n la altura de tu plataforma)
    public float limiteInferior = -1f;   // L�mite inferior de movimiento (ajusta seg�n la altura de tu plataforma)

    private float posicionInicialY;
    void Start()
    {
        // Guarda la posici�n inicial en el eje Y
        posicionInicialY = transform.position.y;
    }

    

    void Update()
    {// Calcula el desplazamiento vertical utilizando la funci�n PingPong
        float desplazamientoY = Mathf.PingPong(Time.time * velocidad, amplitud * 2) - amplitud;

        // Calcula la nueva posici�n en el eje Y
        float nuevaPosicionY = posicionInicialY + desplazamientoY;

        // Limita la posici�n de la plataforma entre los l�mites superior e inferior
        nuevaPosicionY = Mathf.Clamp(nuevaPosicionY, limiteInferior, limiteSuperior);

        // Actualiza la posici�n de la plataforma en el eje Y
        transform.position = new Vector3(transform.position.x, nuevaPosicionY, transform.position.z);
    }
}

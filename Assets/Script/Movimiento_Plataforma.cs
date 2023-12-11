using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Plataforma : MonoBehaviour
{
    public float amplitud = 2f;    // Amplitud del movimiento en el eje Y
    public float velocidad = 2f;   // Velocidad de movimiento de la plataforma
    public float limiteSuperior = 1f;   // Límite superior de movimiento (ajusta según la altura de tu plataforma)
    public float limiteInferior = -1f;   // Límite inferior de movimiento (ajusta según la altura de tu plataforma)

    private float posicionInicialY;
    void Start()
    {
        // Guarda la posición inicial en el eje Y
        posicionInicialY = transform.position.y;
    }

    

    void Update()
    {// Calcula el desplazamiento vertical utilizando la función PingPong
        float desplazamientoY = Mathf.PingPong(Time.time * velocidad, amplitud * 2) - amplitud;

        // Calcula la nueva posición en el eje Y
        float nuevaPosicionY = posicionInicialY + desplazamientoY;

        // Limita la posición de la plataforma entre los límites superior e inferior
        nuevaPosicionY = Mathf.Clamp(nuevaPosicionY, limiteInferior, limiteSuperior);

        // Actualiza la posición de la plataforma en el eje Y
        transform.position = new Vector3(transform.position.x, nuevaPosicionY, transform.position.z);
    }
}

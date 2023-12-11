using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_ParedCorredera : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad de movimiento del muro
    public float distancia = 5f; // Distancia total que recorrer� el muro

    private bool haciaDerecha = true;
    private Vector3 posicionInicial;

    void Start()
    {
        // Guarda la posici�n inicial del muro
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en la direcci�n adecuada
        float desplazamiento = haciaDerecha ? velocidad : -velocidad;

        // Mueve el muro
        transform.Translate(new Vector3(desplazamiento, 0, 0) * Time.deltaTime);

        // Verifica si el muro ha alcanzado el l�mite y cambia la direcci�n
        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= distancia / 2)
        {
            haciaDerecha = !haciaDerecha;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_ParedCorredera : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad de movimiento del muro
    public float distancia = 5f; // Distancia total que recorrerá el muro

    private bool haciaDerecha = true;
    private Vector3 posicionInicial;

    void Start()
    {
        // Guarda la posición inicial del muro
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en la dirección adecuada
        float desplazamiento = haciaDerecha ? velocidad : -velocidad;

        // Mueve el muro
        transform.Translate(new Vector3(desplazamiento, 0, 0) * Time.deltaTime);

        // Verifica si el muro ha alcanzado el límite y cambia la dirección
        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= distancia / 2)
        {
            haciaDerecha = !haciaDerecha;
        }
    }

}

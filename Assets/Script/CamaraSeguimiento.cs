using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    // Referencia al objeto del jugador y su script de movimiento.
    public GameObject jugador;
    public Movimiento personaje;
    // Vector que representa la distancia relativa entre la cámara y el jugador.
    Vector3 distancia;
    float alturaInicial;
    // Parámetro de suavidad para la transición de posición de la cámara.
    public float suavidad = 10f;

    void Start()
    {
        // Calcula y almacena la distancia inicial entre la cámara y el jugador.
        distancia = transform.position - jugador.transform.position;
        // Almacena la altura inicial de la cámara.
        alturaInicial = transform.position.y;
    }

    void LateUpdate()
    {
        // Vector que representa la posición objetivo de la cámara.
        Vector3 targetPosition;
        // Verifica si el jugador está en el suelo.
        if (personaje.suelo())
        {
            // Si el jugador está en el suelo, la posición objetivo es ajustada para seguir al jugador en todas las dimensiones.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                jugador.transform.position.y + distancia.y,
                jugador.transform.position.z + distancia.z
            );
            // Actualiza la altura inicial de la cámara para seguir al jugador en altura.
            alturaInicial = transform.position.y;
        }
        else
        {
            // Si el jugador no está en el suelo, la cámara mantiene su altura inicial y sigue al jugador solo en el plano XZ.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                alturaInicial, // Mantén la altura inicial de la cámara
                jugador.transform.position.z + distancia.z);
        }
        // Utiliza la función Lerp para suavizar la transición de posición de la cámara hacia la posición objetivo.
        transform.position = Vector3.Lerp(transform.position, targetPosition, suavidad * Time.deltaTime);







    }
}

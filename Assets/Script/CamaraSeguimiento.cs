using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    // Referencia al objeto del jugador y su script de movimiento.
    public GameObject jugador;
    public Movimiento personaje;
    // Vector que representa la distancia relativa entre la c�mara y el jugador.
    Vector3 distancia;
    float alturaInicial;
    // Par�metro de suavidad para la transici�n de posici�n de la c�mara.
    public float suavidad = 10f;

    void Start()
    {
        // Calcula y almacena la distancia inicial entre la c�mara y el jugador.
        distancia = transform.position - jugador.transform.position;
        // Almacena la altura inicial de la c�mara.
        alturaInicial = transform.position.y;
    }

    void LateUpdate()
    {
        // Vector que representa la posici�n objetivo de la c�mara.
        Vector3 targetPosition;
        // Verifica si el jugador est� en el suelo.
        if (personaje.suelo())
        {
            // Si el jugador est� en el suelo, la posici�n objetivo es ajustada para seguir al jugador en todas las dimensiones.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                jugador.transform.position.y + distancia.y,
                jugador.transform.position.z + distancia.z
            );
            // Actualiza la altura inicial de la c�mara para seguir al jugador en altura.
            alturaInicial = transform.position.y;
        }
        else
        {
            // Si el jugador no est� en el suelo, la c�mara mantiene su altura inicial y sigue al jugador solo en el plano XZ.
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                alturaInicial, // Mant�n la altura inicial de la c�mara
                jugador.transform.position.z + distancia.z);
        }
        // Utiliza la funci�n Lerp para suavizar la transici�n de posici�n de la c�mara hacia la posici�n objetivo.
        transform.position = Vector3.Lerp(transform.position, targetPosition, suavidad * Time.deltaTime);







    }
}

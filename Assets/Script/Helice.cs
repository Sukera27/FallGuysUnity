using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helice : MonoBehaviour
{
    public float velocidadRotacion = 15f;
    public Transform centroDeRotacion; // El GameObject vac�o alrededor del cual quieres rotar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obt�n la posici�n del centro de rotaci�n
        Vector3 centroPosition = centroDeRotacion.position;

        // Calcula el vector desde el centro de rotaci�n hasta la posici�n actual del objeto
        Vector3 direccionDesdeCentro = transform.position - centroPosition;

        // Rota el objeto alrededor del centro de rotaci�n
        transform.RotateAround(centroPosition, Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}

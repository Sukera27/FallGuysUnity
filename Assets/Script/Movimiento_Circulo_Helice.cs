using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Circulo_Helice : MonoBehaviour
{
    public float velocidadRotacion = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar el objeto alrededor de su propio eje hacia la derecha
        transform.Rotate(-Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}

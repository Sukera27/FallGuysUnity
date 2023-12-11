using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspas : MonoBehaviour
{
    public float velocidadRotacion = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CambiarDireccionRotacion());
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar el objeto alrededor de su propio eje hacia la derecha
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
    IEnumerator CambiarDireccionRotacion()
    {
        while (true)
        {
            // Espera tres segundos
            yield return new WaitForSeconds(3f);

            // Cambia la dirección de rotación invirtiendo la velocidad
            velocidadRotacion *= -1;
        }
    }
}

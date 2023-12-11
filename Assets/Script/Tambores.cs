using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambores : MonoBehaviour
{
    public float velocidadRotacion = 5f;
    public float fuerzaEmpuje = 10f; // Fuerza de empuje al chocar con el personaje
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
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la dirección del empuje
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la dirección

            // Agrega un componente lateral al empuje (usando el eje X, por ejemplo)
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y dirección según sea necesario

            // Aplica el empuje al personaje
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
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

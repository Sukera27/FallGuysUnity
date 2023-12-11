using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{
    
    public float velocidadAngular = 1f;   // Velocidad angular del p�ndulo
    public float amplitud = 2f;           // Amplitud de la oscilaci�n en X
    public float fuerzaEmpuje = 10f; // Fuerza de empuje al chocar con el personaje
    private Quaternion rotationInitial;



    // Start is called before the first frame update
    void Start()
    {
        rotationInitial = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {// Obtener el �ngulo actual basado en el tiempo
        float angulo = amplitud*Mathf.Sin(Time.time * velocidadAngular);

       

        // Actualizar la posici�n del p�ndulo
        transform.rotation = rotationInitial*Quaternion.Euler(0f,angulo,0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la direcci�n del empuje
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la direcci�n

            // Agrega un componente lateral al empuje (usando el eje X, por ejemplo)
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y direcci�n seg�n sea necesario

            // Aplica el empuje al personaje
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}

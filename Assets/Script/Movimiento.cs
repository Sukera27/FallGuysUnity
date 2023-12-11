using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    
    public float speed = 5f;
    public float velocidadRotacion = 200.0f;
    public Vector3 posicionInicial;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float jumpForce=8f;
    public bool puedoSaltar;
    public static Movimiento Instance;
    public int vidas = 3; // Añadida variable de vidas
    private bool yaPerdioVida = false; // Nueva variable
    public GameObject victoria;
    public GameObject perder;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;




    void Start()
    {
        // Establecer la posición inicial y desactivar la capacidad de saltar inicialmente.
        posicionInicial = transform.position;
        puedoSaltar = false;
        anim =GetComponent<Animator>();
       

    }


    void Update()
    {
        
        x =Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Calcular el movimiento en base a la entrada del teclado
        Vector3 movimiento = new Vector3(x, 0.0f, y) * speed * Time.deltaTime;

        // Aplicar el movimiento al personaje
        transform.Translate(movimiento);

        // Actualizar la animación con las velocidades de entrada.
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
        if (puedoSaltar)
        {
            if(Input.GetKeyDown(KeyCode.Space)) {
                anim.SetBool("salte", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);


                // Reproduce el sonido de salto
                GetComponent<AudioSource>().Play();
            }
            anim.SetBool("tocarSuelo", true);
        }
        else
        {
            estoyCayendo();
        }
        
        // Obtener la entrada del jugador
        


    }
    public void estoyCayendo()
    {
        anim.SetBool("tocarSuelo", false);
        anim.SetBool("salte", false);
    }
    // Metodo para detectar varias Colisiones
    private void OnTriggerEnter(Collider other)
    {
        // CheckPoints
        if (other.gameObject.CompareTag("checkpoint")) // Si choca con un gameObject con el TAG "checkpoint"
        {
            posicionInicial = transform.position; // Iguala la variable de la posicion inicial, a la posicion que tenga en ese momento
        }
        if (other.gameObject.CompareTag("checkpoint2"))
        {
            posicionInicial = transform.position;
            Debug.Log("checkpoint guardado en:" + posicionInicial);
        }

      


        

    }
    private void OnCollisionEnter(Collision other)
    {
       
        // Condicion para eliminar al personaje en las helices de los circulos del final del mapa
        if (other.gameObject.CompareTag("RespawnGeneral")) // Si choca con un gameObject con el TAG 
        {
           
            Debug.Log("palaDisco manda al jugador a:" + posicionInicial);
            transform.position = posicionInicial;

            // Restablecer la bandera para indicar que se ha perdido una vida
            yaPerdioVida = false;

            //rb.MovePosition(posicionInicial); // Mueve el personaje a la ultima posicion guardada
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // Reducir una vida cuando el jugador toca la trampa (si aún le quedan vidas)
            if (vidas > 0)
            {
                PerderVida();
                yaPerdioVida = true; // Marcar que se ha perdido una vida
            }

        }
        if (other.gameObject.CompareTag("Meta"))
        {
            victoria.SetActive(true);
        }
    }
    public bool suelo()
    {   
        //coge el transform position en el vector que coja significa que esta en el suelo
        bool suelo = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        if (suelo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void PerderVida()
    {
        vidas--;

        if (vidas == 2)
        {
            corazon3.SetActive(false);
            
            
        }
        if(vidas == 1)
        {
            corazon2.SetActive(false);
        }
        if (vidas == 0)
        {
            corazon1.SetActive(false);
        }

        if (vidas == 0)
        {
            
            Debug.Log("Has perdido todas las vidas. Fin del juego.");
            // Reiniciar el nivel o realizar otras acciones necesarias.
            perder.SetActive(true);
            //paraliza la pantalla
            Time.timeScale = 0;
        }
        else
        {
            // Si aún quedan vidas, reiniciar desde el último punto de guardado.
            rb.MovePosition(posicionInicial);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Te quedan " + vidas + " vidas.");
        }
    }




}

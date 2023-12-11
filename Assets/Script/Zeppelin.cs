using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeppelin : MonoBehaviour
{
    public float forwardSpeed = 9f;  //  La velocidad de avance del zepelín.
    public Transform destinationPoint;
    public float waitTime = 1f;

    private Vector3 initialPosition;

    void Start()
    {
        // Guardar Posicion Inical
        initialPosition = transform.position;

        // Iniciar Coroutina
        StartCoroutine(CombinedZeppelinMovementCoroutine());
    }
     void Update()
    {
        
    }

    IEnumerator CombinedZeppelinMovementCoroutine()
    {
        while (true)
        {
            //Mover el zeppelin
            float distanceToDestination = Vector3.Distance(transform.position, destinationPoint.position);
            float timeToReachDestination = distanceToDestination / forwardSpeed;

            while (timeToReachDestination > 0f)
            {
                transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
                timeToReachDestination -= Time.deltaTime;
                yield return null;
            }

            // Asegura que el zepelín esté exactamente en el destino.
            transform.position = destinationPoint.position;

            // Espera el tiempo especificado
            yield return new WaitForSeconds(waitTime);

            // Mueve el zepelín de nuevo a la posición inicial.
            float timeToReachInitial = Vector3.Distance(transform.position, initialPosition) / forwardSpeed;

            while (timeToReachInitial > 0f)
            {
                transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
                timeToReachInitial -= Time.deltaTime;
                yield return null;
            }

            // Asegúrese de que el zepelín esté exactamente en la posición inicial.
            transform.position = initialPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeppelin : MonoBehaviour
{
    public float forwardSpeed = 9f;  //  La velocidad de avance del zepel�n.
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

            // Asegura que el zepel�n est� exactamente en el destino.
            transform.position = destinationPoint.position;

            // Espera el tiempo especificado
            yield return new WaitForSeconds(waitTime);

            // Mueve el zepel�n de nuevo a la posici�n inicial.
            float timeToReachInitial = Vector3.Distance(transform.position, initialPosition) / forwardSpeed;

            while (timeToReachInitial > 0f)
            {
                transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
                timeToReachInitial -= Time.deltaTime;
                yield return null;
            }

            // Aseg�rese de que el zepel�n est� exactamente en la posici�n inicial.
            transform.position = initialPosition;
        }
    }
}

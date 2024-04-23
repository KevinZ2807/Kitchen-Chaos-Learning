using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameInput gameInput;

    [Header("Attributes")]
    [SerializeField] private float speed = 7f;
    private bool isWalking;


    void Update()
    {
        Move();
    }

    private void Move() {
        // Option 1
        Vector3 inputVector = gameInput.GetMovementVector3Slerp();
        // Option 2
        //Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        transform.position += speed * Time.deltaTime * inputVector;

        isWalking = inputVector != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, inputVector, Time.deltaTime * rotationSpeed); // Slerp use for slowly rotation, prevent instant rotation
        
    }

    public bool IsWalking() {    
        return isWalking;
    }
}

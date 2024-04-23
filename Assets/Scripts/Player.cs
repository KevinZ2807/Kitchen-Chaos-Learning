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
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += speed * Time.deltaTime * moveDir;

        isWalking = moveDir != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, inputVector, Time.deltaTime * rotationSpeed); // Slerp use for slowly rotation, prevent instant rotation
        
    }

    public bool IsWalking() {    
        return isWalking;
    }
}

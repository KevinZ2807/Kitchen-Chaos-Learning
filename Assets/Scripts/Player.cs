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
        float moveDistance = speed * Time.deltaTime;

        float playerRadius = .7f;
        float playerHeight = 2f;
        //              Physics.CapsuleCast(toa do bottom, toa do top * Vector3.up * do cao cua nguoi choi,     kich co,   huong di chuyen, khoang cach di chuyen)
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            // Co gang di chuyen hàng ngang X
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove) {
                moveDir = moveDirX; // Doi huong di chuyen thanh hang ngang only
            } else {
                // Neu khong the hang ngang thi hang doc Z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove) moveDir = moveDirZ; // Doi sang huong hang doc only
                else {} // Cannot move any direction
            }
        }
        
        if (canMove) transform.position += speed * Time.deltaTime * moveDir;

        isWalking = moveDir != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed); // Slerp use for slowly rotation, prevent instant rotation
        
    }

    public bool IsWalking() {    
        return isWalking;
    }
}

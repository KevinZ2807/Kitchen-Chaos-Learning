using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("References")]


    [Header("Attributes")]
    [SerializeField] private float speed = 7f;

    private float x;
    private float z;
    private bool isWalking;
    void Update()
    {
        Move();
    }

    private void Move() {
        // Option 1
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        transform.position += speed * Time.deltaTime * move;

        isWalking = move != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, move, Time.deltaTime * rotationSpeed); // Slerp use for slowly rotation, prevent instant rotation

        // Option 2
        /*Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.W)) {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * speed * Time.deltaTime;
        */
    }

    public bool IsWalking() {    
        return isWalking;
    }
}

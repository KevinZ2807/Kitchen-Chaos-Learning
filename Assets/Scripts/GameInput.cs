using UnityEngine;

public class GameInput : MonoBehaviour
{
    private float x;
    private float z;
    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = new Vector2(0, 0);
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

        return inputVector;
    }

    public Vector3 GetMovementVector3Slerp() {
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        return move;
    }
}

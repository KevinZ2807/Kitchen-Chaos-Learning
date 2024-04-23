using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction inputActions;

    private void Awake() {
        inputActions = new PlayerInputAction();
        inputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class InputForwarder : MonoBehaviour
{
    public MovementArrows movementScript;

    public void OnMove(InputValue value)
    {
        movementScript.OnMove(value);
    }
}
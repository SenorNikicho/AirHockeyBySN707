using UnityEngine;
using UnityEngine.InputSystem;

public class MovementWASD : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float force = 5f;
    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        if (move != Vector3.zero)
            rb.AddForce(move.normalized * force, ForceMode.Force);
    }
}